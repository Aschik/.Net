using System.Collections.Generic;

namespace MiniTC.Model
{
    interface IPanelTC
    {
        //bieżąca ścieżka
        string CurrentPath { get; set; }
        //kolekcja dostępnych napędów
        string[] AvaibleDrives { get; }
        //kolekcja zawierajaca zawartosc biezacej sciezki
        List<string> CurrentDirectoryContent { get; set; }

        bool getContent(string path);
        bool goDirectory(string dir);
    }
}
