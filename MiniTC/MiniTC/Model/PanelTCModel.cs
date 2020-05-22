using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MiniTC.Model
{
    class PanelTCModel: IPanelTC
    {
        #region Fields

        public string CurrentPath { get; set; }
        public string[] AvaibleDrives => Directory.GetLogicalDrives();
        public List<string> CurrentDirectoryContent { get; set; }

        #endregion

        #region Methods

        public bool getContent(string path)
        {
            CurrentDirectoryContent = new List<string>();
            List<string> listOfFolders;
            List<string> listOfFiles;

            try
            {
                listOfFolders = Directory.GetDirectories(path).ToList();
                listOfFiles = Directory.GetFiles(path).ToList();

                if (!AvaibleDrives.Contains(Path.GetFullPath(path)))
                {
                    CurrentDirectoryContent.Add("..");
                }

                CurrentDirectoryContent.AddRange(listOfFolders.Select(x => "<D>" + Path.GetFileName(x)));
                CurrentDirectoryContent.AddRange(listOfFiles.Select(x => Path.GetFileName(x)));
                CurrentPath = Path.GetFullPath(path);

                return true;
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                return false;
            }
        }
        public bool goDirectory(string dir)
        {
            if (dir == null)
            {
                return true;
            }
            if (dir.Contains("<D>"))
            {
                string path = CurrentPath + @"\" + dir.Substring(3);
                return getContent(path);
            }
            if (dir.Contains(".."))
            {
                string path = CurrentPath + @"\" + dir;
                return getContent(path);
            }
            return true;
        }

        #endregion
    }
}
