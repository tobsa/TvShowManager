using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

namespace TvShowManagerWPF.TvShowTracker.TvShows
{
    public partial class TvShows : UserControl
    {
        public TvShows()
        {
            InitializeComponent();
        }

        private void TvShows_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject())) return;

            ((TvShowsViewModel)DataContext)?.LoadTvShows();
        }
    }
}
