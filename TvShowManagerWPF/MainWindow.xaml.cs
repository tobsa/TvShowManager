using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TvShowManagerLibrary;
using TvShowManagerLibrary.Configurations;
using TvShowManagerWPF.TvShowTracker;

namespace TvShowManagerWPF
{
    public partial class MainWindow : Window
    {
        private bool mRestoreIfMove = false;

        public MainWindow()
        {
            InitializeComponent();
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
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
                mRestoreIfMove = true;
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
            if (mRestoreIfMove)
            {
                mRestoreIfMove = false;

                var point = PointToScreen(e.MouseDevice.GetPosition(this));

                Left = point.X - (RestoreBounds.Width  * point.X / ActualWidth);
                Top =  point.Y - (RestoreBounds.Height * point.Y / ActualHeight);

                WindowState = WindowState.Normal;

                DragMove();
            }
        }

        private void UIElement_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            mRestoreIfMove = false;
            e.Handled = true;
        }

        private void CloseButton_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
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
