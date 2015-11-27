using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CoreLibrary;
using TvShowManagerLibrary;
using TvShowManagerLibrary.Configurations;
using TvShowManagerLibrary.ExternalServices;
using TvShowManagerLibrary.Repositories;
using TvShowManagerLibrary.Services;
using TvShowManagerWPF.TvShowTracker.TvShowDetails;
using TvShowManagerWPF.TvShowTracker.TvShows;
using TvShowManagerWPF.TvShowTracker.TvShowsSearched;
using TvShowManagerWPF.TvShowTracker.TvShowLatestNews;
using TvShowManagerWPF.TvShowTracker.TvShowsArchived;

namespace TvShowManagerWPF.TvShowTracker
{
    public class TvShowTrackerViewModel : BaseViewModel
    {
        private BaseViewModel currentViewModel;
        private readonly TvShowsViewModel shows = new TvShowsViewModel();
        private readonly TvShowsSearchedViewModel searchedTvShows = new TvShowsSearchedViewModel();
        private readonly TvShowDetailsViewModel showDetails = new TvShowDetailsViewModel();
        private readonly TvShowsArchivedViewModel archivedShows = new TvShowsArchivedViewModel();
        private TvShowLatestNewsViewModel tvShowLatestNewsViewModel = new TvShowLatestNewsViewModel();

        private bool isTvShowsChecked;
        private bool _isTvShowsArchivedChecked;

        public TvShowTrackerViewModel()
        {
            SearchCommand = new RelayCommand(OnSearchTvShows);
            NavigateCommand = new RelayCommand<Navigations>(OnNavigation);

            shows.DisplayTvShowDetailsRequested += DisplayTvShowDetails;
            searchedTvShows.DisplayTvShowDetailsRequested += DisplayTvShowDetails;
            archivedShows.DisplayTvShowDetailsRequested += DisplayTvShowDetails;
            showDetails.TvShowSubscriptionChanged += TvShowSubscriptionChanged;
            showDetails.TvShowArchiveChanged += TvShowArchiveChanged;
            
            CurrentViewModel = shows;
            IsTvShowsChecked = true;
        }

        public BaseViewModel CurrentViewModel
        {
            get { return currentViewModel; }
            set { currentViewModel = value; OnPropertyChanged(); }
        }

        public bool IsTvShowsChecked
        {
            get { return isTvShowsChecked; }
            set { isTvShowsChecked = value; OnPropertyChanged(); }
        }

        public bool IsTvShowsArchivedChecked
        {
            get { return _isTvShowsArchivedChecked; }
            set { _isTvShowsArchivedChecked = value; OnPropertyChanged(); }
        }

        public string TextBoxSearchQuery { get; set; }

        public RelayCommand SearchCommand { get; private set; }
        public RelayCommand<Navigations> NavigateCommand { get; private set; } 

        public void OnNavigation(Navigations navigation)
        {
            switch (navigation)
            {
                case Navigations.TvShows:
                    CurrentViewModel = shows;
                    break;
                case Navigations.TvShowDetails:
                    CurrentViewModel = showDetails;
                    IsTvShowsChecked = false;
                    IsTvShowsArchivedChecked = false;
                    break;
                case Navigations.TvShowsSearched:
                    CurrentViewModel = searchedTvShows;
                    IsTvShowsChecked = false;
                    IsTvShowsArchivedChecked = false;
                    break;
                case Navigations.TvShowsArchived:
                    CurrentViewModel = archivedShows;
                    break;
            }
        }

        private void OnSearchTvShows()
        {
            searchedTvShows.TvShows = TvShowService.SearchTvShows(TextBoxSearchQuery, ConfigurationData.NoImageFoundPath).ToObservableCollection();
            OnNavigation(Navigations.TvShowsSearched);
        }

        private void DisplayTvShowDetails(TvShow show)
        {
            if (show != null)
            {
                showDetails.TvShow = show;
                OnNavigation(Navigations.TvShowDetails);
            }
        }

        private void TvShowSubscriptionChanged(TvShow show)
        {
            if (show == null)
                return;

            if (TvShowService.IsSubscribing(show))
                TvShowService.Unsubscribe(show);
            else
                TvShowService.Subscribe(show);

            showDetails.TvShow = show;
            shows.TvShows = TvShowService.GetActiveTvShows().ToObservableCollection();
            archivedShows.TvShows = TvShowService.GetArchivedTvShows().ToObservableCollection();
        }

        private void TvShowArchiveChanged(TvShow show)
        {
            if (show == null)
                return;

            showDetails.TvShow = show;
            shows.TvShows = TvShowService.GetActiveTvShows().ToObservableCollection();
            archivedShows.TvShows = TvShowService.GetArchivedTvShows().ToObservableCollection();
        }
    }
}