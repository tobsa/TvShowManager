using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;
using TvShowManagerLibrary;
using TvShowManagerLibrary.Configurations;
using TvShowManagerWPF.TvShowTracker;
using Application = System.Windows.Application;
using ContextMenu = System.Windows.Forms.ContextMenu;
using MenuItem = System.Windows.Forms.MenuItem;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;

namespace TvShowManagerWPF
{
    public partial class MainWindow : Window
    {
        private bool restoreIfMoved;

        public MainWindow()
        {
            InitializeComponent();
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            //var streamResourceInfo = Application.GetResourceStream(new Uri("Content/Icon.ico", UriKind.Relative));
            //if (streamResourceInfo != null)
            //{
            //    var notifyIcon = new NotifyIcon
            //    {
            //        Icon = new Icon(streamResourceInfo.Stream),
            //        Visible = true
            //    };
            //    notifyIcon.DoubleClick += delegate
            //    {
            //        if (IsVisible)
            //        {
            //            Hide();
            //        }
            //        else
            //        {
            //            Show();
            //        }
            //    };

            //    var menu = new ContextMenu();

            //    var minimize = new MenuItem("Minimize to system tray");
            //    minimize.Click += delegate { Hide(); };

            //    var exit = new MenuItem("Exit");
            //    exit.Click += delegate { Application.Current.Shutdown(); };

            //    menu.MenuItems.Add(minimize);
            //    menu.MenuItems.Add(new MenuItem("-"));
            //    menu.MenuItems.Add(exit);

            //    notifyIcon.ContextMenu = menu;
            //}
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (ResizeMode == ResizeMode.CanResize || ResizeMode == ResizeMode.CanResizeWithGrip)
                {
                    SwitchWindowState();
                }
            }
            else if (WindowState == WindowState.Maximized)
            {
                restoreIfMoved = true;
            }
            else
            {
                DragMove();
            }
        }

        private void SwitchWindowState()
        {
            switch (WindowState)
            {
                case WindowState.Normal:
                {
                    WindowState = WindowState.Maximized;
                    break;
                }
                case WindowState.Maximized:
                {
                    WindowState = WindowState.Normal;
                    break;
                }
            }
        }

        private void UIElement_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (restoreIfMoved)
            {
                restoreIfMoved = false;

                var point = PointToScreen(e.MouseDevice.GetPosition(this));

                Left = point.X - (RestoreBounds.Width  * point.X / ActualWidth);
                Top =  point.Y - (RestoreBounds.Height * point.Y / ActualHeight);

                WindowState = WindowState.Normal;

                DragMove();
            }
        }

        private void UIElement_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            restoreIfMoved = false;
            e.Handled = true;
        }

        private void CloseButton_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            //Hide();
            Application.Current.Shutdown();
        }

        private void MaximizeButton_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            SwitchWindowState();
        }

        private void MinimizeButton_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }


}
