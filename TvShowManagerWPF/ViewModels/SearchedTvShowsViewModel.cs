using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvShowManagerLibrary;

namespace TvShowManagerWPF.ViewModels
{
    public class SearchedTvShowsViewModel : ViewModel
    {
        private ObservableCollection<TvShow> searchedTvShows;
        private bool isSearchedTvShowSelected;
        private bool isTvShowDetailsSelected;
        private TvShow tvShowDetails;
        private bool isTvShowSubscribed;

        public ObservableCollection<TvShow> SearchedTvShows
        {
            get { return searchedTvShows; }
            set { searchedTvShows = value; OnPropertyChanged(); }
        }

        public bool IsSearchedTvShowSelected
        {
            get { return isSearchedTvShowSelected; }
            set { isSearchedTvShowSelected = value; OnPropertyChanged(); }
        }

        public TvShow TvShowDetails
        {
            get { return tvShowDetails; }
            set { tvShowDetails = value; OnPropertyChanged(); }
        }

        public bool IsTvShowDetailsSelected
        {
            get { return isTvShowDetailsSelected; }
            set { isTvShowDetailsSelected = value; OnPropertyChanged(); }
        }

        public bool IsTvShowSubscribed
        {
            get { return isTvShowSubscribed; }
            set { isTvShowSubscribed = value; OnPropertyChanged(); }
        }
    }
}
