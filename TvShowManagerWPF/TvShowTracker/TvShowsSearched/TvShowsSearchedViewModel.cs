using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvShowManagerLibrary;

namespace TvShowManagerWPF.TvShowTracker.TvShowsSearched
{
    public class TvShowsSearchedViewModel : BaseViewModel
    {
        private ObservableCollection<TvShow> tvShows;
        private string searchQuery;

        public event Action<TvShow> DisplayTvShowDetailsRequested = delegate { };
        public RelayCommand<TvShow> OnDisplayTvShowDetailsCommand { get; private set; }

        public TvShowsSearchedViewModel()
        {
            OnDisplayTvShowDetailsCommand = new RelayCommand<TvShow>(DisplayTvShowDetails);
        }

        public ObservableCollection<TvShow> TvShows
        {
            get { return tvShows; }
            set { tvShows = value; OnPropertyChanged(); }
        }

        public string SearchQuery
        {
            get { return searchQuery; }
            set { searchQuery = value; OnPropertyChanged(); }
        }

        private void DisplayTvShowDetails(TvShow show)
        {
            DisplayTvShowDetailsRequested(show);
        }
    }
}
