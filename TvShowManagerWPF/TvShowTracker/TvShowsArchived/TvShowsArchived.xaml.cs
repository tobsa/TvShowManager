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

namespace TvShowManagerWPF.TvShowTracker.TvShowsArchived
{
    public partial class TvShowsArchived : UserControl
    {
        public TvShowsArchived()
        {
            InitializeComponent();
        }

        private void TvShowsArchived_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;
            
            ((TvShowsArchivedViewModel)DataContext)?.LoadTvShows();
        }
    }
}
