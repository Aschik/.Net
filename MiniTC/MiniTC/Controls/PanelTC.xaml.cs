using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MiniTC.Controls
{
    public partial class PanelTC: UserControl
    {
        public PanelTC()
        {
            InitializeComponent();
        }

        #region Register DependencyProperty


        //Drives
        public string[] Drives
        {
            get => (string[])GetValue(DrivesDP);
            set => SetValue(DrivesDP, value);
        }

        public static readonly DependencyProperty DrivesDP = DependencyProperty.Register(nameof(Drives), typeof(string[]), typeof(PanelTC), new FrameworkPropertyMetadata(null));

        //CurrentDrive
        public string CurrentDrive
        {
            get => (string)GetValue(CurrentDriveDP);
            set => SetValue(CurrentDriveDP, value);
        }

        public static readonly DependencyProperty CurrentDriveDP = DependencyProperty.Register(nameof(CurrentDrive), typeof(string), typeof(PanelTC), new FrameworkPropertyMetadata(null));

        //CurrentPath
        public string CurrentPath
        {
            get { return (string)GetValue(CurrentPathDP); }
            set { SetValue(CurrentPathDP, value); }
        }
        public static readonly DependencyProperty CurrentPathDP = DependencyProperty.Register(nameof(CurrentPath), typeof(string), typeof(PanelTC), new FrameworkPropertyMetadata(null));

        //File List
        public string CurrentDir
        {
            get { return (string)GetValue(CurrentDirDP); }
            set { SetValue(CurrentDirDP, value); }
        }
        public static readonly DependencyProperty CurrentDirDP = DependencyProperty.Register(nameof(CurrentDir), typeof(List<string>), typeof(PanelTC), new FrameworkPropertyMetadata(null));

        //Selected File
        public string CurrentFile
        {
            get { return (string)GetValue(CurrentFileDP); }
            set { SetValue(CurrentFileDP, value); }
        }
        public static readonly DependencyProperty CurrentFileDP = DependencyProperty.Register(nameof(CurrentFile), typeof(string), typeof(PanelTC), new FrameworkPropertyMetadata(null));





        #endregion

        #region Register Events

        //ChangeDrive
        public static readonly RoutedEvent ChangeDriveEvent = EventManager.RegisterRoutedEvent(nameof(ChangeDrive), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PanelTC));
        public event RoutedEventHandler ChangeDrive
        {
            add { AddHandler(ChangeDriveEvent, value); }
            remove { RemoveHandler(ChangeDriveEvent, value); }
        }

        //ChangeCurrentFile
        public static readonly RoutedEvent ChangeCurrentFileEvent = EventManager.RegisterRoutedEvent(nameof(ChangeCurrentFile), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PanelTC));
        public event RoutedEventHandler ChangeCurrentFile
        {
            add { AddHandler(ChangeCurrentFileEvent, value); }
            remove { RemoveHandler(ChangeCurrentFileEvent, value); }
        }

        //Mouse Double Click
        public static readonly RoutedEvent MouseDoubleClickEvent = EventManager.RegisterRoutedEvent(nameof(MouseDoubleClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PanelTC));
        public event RoutedEventHandler MouseDoubleClick
        {
            add { AddHandler(MouseDoubleClickEvent, value); }
            remove { RemoveHandler(MouseDoubleClickEvent, value); }
        }

        //Focused Panel Event
        public static readonly RoutedEvent FocusedPanelEvent = EventManager.RegisterRoutedEvent(nameof(FocusedPanel), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PanelTC));
        public event RoutedEventHandler FocusedPanel
        {
            add { AddHandler(FocusedPanelEvent, value); }
            remove { RemoveHandler(FocusedPanelEvent, value); }
        }

        #endregion

        #region Events

        private void Drive_SelectionChanged(object sender, SelectionChangedEventArgs e) => RaiseEvent(new RoutedEventArgs(ChangeDriveEvent));
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => RaiseEvent(new RoutedEventArgs(ChangeCurrentFileEvent));
        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e) => RaiseEvent(new RoutedEventArgs(MouseDoubleClickEvent));
        private void ListBox_GotFocus(object sender, RoutedEventArgs e) => RaiseEvent(new RoutedEventArgs(FocusedPanelEvent));

        #endregion
    }
}
