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
using TvShowManagerWPF.TvShowTracker.TvShowsPopular;
using TvShowManagerWPF.TvShowTracker.TvShowsTopRated;

namespace TvShowManagerWPF.TvShowTracker
{
    public class TvShowTrackerViewModel : BaseViewModel
    {
        private BaseViewModel currentViewModel;
        private readonly TvShowsViewModel shows = new TvShowsViewModel();
        private readonly TvShowsSearchedViewModel searchedTvShows = new TvShowsSearchedViewModel();
        private readonly TvShowDetailsViewModel showDetails = new TvShowDetailsViewModel();
        private readonly TvShowsArchivedViewModel archivedShows = new TvShowsArchivedViewModel();
        private TvShowLatestNewsViewModel latestNews = new TvShowLatestNewsViewModel();
        private readonly TvShowsPopularViewModel popularShows = new TvShowsPopularViewModel();
        private readonly TvShowsTopRatedViewModel topRatedShows = new TvShowsTopRatedViewModel();
        private bool isTvShowsChecked;
        private bool isTvShowsArchivedChecked;
        private bool isTvShowsPopularChecked;
        private bool isTvShowsTopRatedChecked;
        private readonly NavigationStateService navigationService;

        public TvShowTrackerViewModel()
        {
            navigationService = new NavigationStateService();

            SearchCommand = new RelayCommand(OnSearchTvShows);
            NavigateCommand = new RelayCommand<Navigation>(OnNavigation);
            NavigateForwardCommand = new RelayCommand(NavigateForward);
            NavigateBackwardCommand = new RelayCommand(NavigateBackward);

            shows.DisplayTvShowDetailsRequested += DisplayTvShowDetails;
            searchedTvShows.DisplayTvShowDetailsRequested += DisplayTvShowDetails;
            archivedShows.DisplayTvShowDetailsRequested += DisplayTvShowDetails;
            popularShows.DisplayTvShowDetailsRequested += DisplayTvShowDetails;
            topRatedShows.DisplayTvShowDetailsRequested += DisplayTvShowDetails;
            showDetails.TvShowSubscriptionChanged += TvShowSubscriptionChanged;
            showDetails.TvShowArchiveChanged += TvShowArchiveChanged;
            
            IsTvShowsChecked = true;
        }

        public void LoadTvShows()
        {
            shows.LoadTvShows();
            OnNavigation(Navigation.TvShows);
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
            get { return isTvShowsArchivedChecked; }
            set { isTvShowsArchivedChecked = value; OnPropertyChanged(); }
        }

        public bool IsTvShowsPopularChecked
        {
            get { return isTvShowsPopularChecked; }
            set { isTvShowsPopularChecked = value; OnPropertyChanged(); }
        }

        public bool IsTvShowsTopRatedChecked
        {
            get { return isTvShowsTopRatedChecked; }
            set { isTvShowsTopRatedChecked = value; OnPropertyChanged(); }
        }

        public TvShowLatestNewsViewModel TvShowLatestNewsViewModel
        {
            get { return latestNews; }
            set { latestNews = value; OnPropertyChanged(); }
        }

        public string TextBoxSearchQuery { get; set; }

        public RelayCommand SearchCommand { get; private set; }
        public RelayCommand<Navigation> NavigateCommand { get; private set; } 
        public RelayCommand NavigateForwardCommand { get; private set; } 
        public RelayCommand NavigateBackwardCommand { get; private set; } 

        public void OnNavigation(Navigation navigation)
        {
            switch (navigation)
            {
                case Navigation.TvShows:
                    CurrentViewModel = shows;
                    navigationService.AddNavigationState(new TvShowsNavigationState());
                    break;
                case Navigation.TvShowDetails:
                    CurrentViewModel = showDetails;
                    SetCheckedStatusOnAllControls(false);
                    navigationService.AddNavigationState(new TvShowDetailsNavigationState(showDetails));
                    break;
                case Navigation.TvShowsSearched:
                    CurrentViewModel = searchedTvShows;
                    SetCheckedStatusOnAllControls(false);
                    navigationService.AddNavigationState(new TvShowsSearchedNavigationState(searchedTvShows));
                    break;
                case Navigation.TvShowsArchived:
                    CurrentViewModel = archivedShows;
                    navigationService.AddNavigationState(new TvShowsArchivedNavigationState());
                    break;
                case Navigation.TvShowsPopular:
                    CurrentViewModel = popularShows;
                    navigationService.AddNavigationState(new TvShowsPopularNavigationState());
                    break;
                case Navigation.TvShowsTopRated:
                    CurrentViewModel = topRatedShows;
                    navigationService.AddNavigationState(new TvShowsTopRatedNavigationState());
                    break;
            }
        }

        public void OnHistoryNavigation(Navigation navigation)
        {
            switch (navigation)
            {
                case Navigation.TvShows:
                    CurrentViewModel = shows;
                    IsTvShowsChecked = true;
                    break;
                case Navigation.TvShowDetails:
                    CurrentViewModel = showDetails;
                    SetCheckedStatusOnAllControls(false);
                    break;
                case Navigation.TvShowsSearched:
                    CurrentViewModel = searchedTvShows;
                    SetCheckedStatusOnAllControls(false);
                    break;
                case Navigation.TvShowsArchived:
                    CurrentViewModel = archivedShows;
                    IsTvShowsArchivedChecked = true;
                    break;
                case Navigation.TvShowsPopular:
                    CurrentViewModel = popularShows;
                    IsTvShowsPopularChecked = true;
                    break;
                case Navigation.TvShowsTopRated:
                    CurrentViewModel = topRatedShows;
                    IsTvShowsTopRatedChecked = true;
                    break;
            }
        }

        public void NavigateForward()
        {
            OnHistoryNavigation(navigationService.NavigateForward());
        }

        public void NavigateBackward()
        {
            OnHistoryNavigation(navigationService.NavigateBackward());
        }

        private void SetCheckedStatusOnAllControls(bool status)
        {
            IsTvShowsChecked = status;
            IsTvShowsArchivedChecked = status;
            IsTvShowsPopularChecked = status;
            IsTvShowsTopRatedChecked = status;
        }

        private void OnSearchTvShows()
        {
            searchedTvShows.TvShows = TvShowService.SearchTvShows(TextBoxSearchQuery, ConfigurationData.NoImageFoundPath).ToObservableCollection();
            searchedTvShows.SearchQuery = TextBoxSearchQuery;
            OnNavigation(Navigation.TvShowsSearched);
        }

        private void DisplayTvShowDetails(TvShow show)
        {
            if (show != null)
            {
                showDetails.TvShow = show;
                OnNavigation(Navigation.TvShowDetails);
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