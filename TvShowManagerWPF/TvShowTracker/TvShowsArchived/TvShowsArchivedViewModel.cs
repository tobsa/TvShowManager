using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary;
using TvShowManagerLibrary;
using TvShowManagerLibrary.Services;

namespace TvShowManagerWPF.TvShowTracker.TvShowsArchived
{
    public class TvShowsArchivedViewModel : BaseViewModel
    {
        private ObservableCollection<TvShow> _tvShows;

        public event Action<TvShow> DisplayTvShowDetailsRequested = delegate { };
        public RelayCommand<TvShow> OnDisplayTvShowDetailsCommand { get; private set; }

        public TvShowsArchivedViewModel()
        {
            OnDisplayTvShowDetailsCommand = new RelayCommand<TvShow>(OnDisplayTvShowDetails);
        }

        public void LoadTvShows()
        {
            TvShows = TvShowService.GetArchivedTvShows().ToObservableCollection();
        }

        public ObservableCollection<TvShow> TvShows
        {
            get { return _tvShows; }
            set { _tvShows = value; OnPropertyChanged(); }
        }

        private void OnDisplayTvShowDetails(TvShow show)
        {
            DisplayTvShowDetailsRequested(show);
        }
    }
}
