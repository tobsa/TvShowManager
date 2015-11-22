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
        private readonly TvShowService servive;
        private ObservableCollection<TvShow> shows;

        public event Action<TvShow> OnDisplayTvShowDetailsRequested = delegate { };

        public RelayCommand<TvShow> OnDisplayTvShowDetailsCommand { get; private set; }

        public TvShowsArchivedViewModel()
        {
        }

        public TvShowsArchivedViewModel(TvShowService service)
        {
            this.servive = service;

            Shows = service.GetArchivedTvShows().ToObservableCollection();
            OnDisplayTvShowDetailsCommand = new RelayCommand<TvShow>(OnDisplayTvShowDetails);
        }

        public ObservableCollection<TvShow> Shows
        {
            get { return shows; }
            set { shows = value; OnPropertyChanged(); }
        }

        private void OnDisplayTvShowDetails(TvShow show)
        {
            OnDisplayTvShowDetailsRequested(show);
        }
    }
}
