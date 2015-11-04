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

namespace TvShowManagerWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Command_SearchExecuted(object sender, RoutedEventArgs e)
        {
            MainWindowDataContext.SearchTvShows(TextBoxTvShowSearchQuery.Text);
            MainWindowDataContext.DisplayTvShowSearchView = true;
        }

        private void Command_SearchedTvShowsSelection(object sender, SelectionChangedEventArgs e)
        {
            MainWindowDataContext.TvShowDetailsViewItem = ListBoxTvShowSearchItems.SelectedItem as TvShow;
            MainWindowDataContext.DisplayTvShowDetailsView = true;
        }
    }
}
