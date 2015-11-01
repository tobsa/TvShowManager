using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class UCNavigationBar : UserControl
    {
        public UCNavigationBar()
        {
            InitializeComponent();
        }

        private void Command_SearchCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Command_SearchExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            DataContext = new SearchedTvShowsViewModel()
            {
                IsSearchedTvShowSelected = true,
                SearchedTvShows = new ObservableCollection<TvShow>()
                {
                    new TvShow()
                    {
                        Name = TextBoxSearchedTvShows.Text,
                        PosterPath =
                            @"F:\Tobias\Programming\Software\TvShowManager\TvShowManagerWPF\Content\NoImageFound.png"
                    },
                    new TvShow()
                    {
                        Name = "Breaking Bad",
                        PosterPath =
                            @"F:\Tobias\Programming\Software\TvShowManager\TvShowManagerWPF\Content\NoImageFound.png"
                    },
                    new TvShow()
                    {
                        Name = "The Big Bang Theory",
                        PosterPath =
                            @"F:\Tobias\Programming\Software\TvShowManager\TvShowManagerWPF\Content\NoImageFound.png"
                    },
                }
            };
        }
    }
}
