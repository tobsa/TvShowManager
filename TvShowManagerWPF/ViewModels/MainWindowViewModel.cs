using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvShowManagerLibrary;

namespace TvShowManagerWPF.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private ObservableCollection<TvShow> _searchedTvShows;
        public ObservableCollection<TvShow> SearchedTvShows
        {
            get { return _searchedTvShows; }
            set { _searchedTvShows = value; OnPropertyChanged(); }
        }
    }
}
