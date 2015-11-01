using System;
using System.Collections.Generic;
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
using TvShowManagerLibrary;
using TvShowManagerWPF.ViewModels;

namespace TvShowManagerWPF.UserControls
{
    public partial class UCSearchedTvShow : UserControl
    {
        public UCSearchedTvShow()
        {
            InitializeComponent();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var context = DataContext as SearchedTvShowsViewModel;
            DataContext = new SearchedTvShowsViewModel()
            {
                IsTvShowDetailsSelected = true,
                TvShowDetails = ListBoxSearchedTvShows.SelectedItem as TvShow,
                SearchedTvShows = context?.SearchedTvShows,
            };
        }
    }
}
