using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using TvShowManagerWPF.TvShowTracker.TvShowDownloader;
using TvShowManagerWPF.TvShowTracker.TvShows;
using TvShowManagerWPF.TvShowTracker.TvShowsSearched;
using TvShowManagerWPF.TvShowTracker.TvShowLatestNews;
using TvShowManagerWPF.TvShowTracker.TvShowsArchived;
using TvShowManagerWPF.TvShowTracker.TvShowsPopular;
using TvShowManagerWPF.TvShowTracker.TvShowsTopRated;
using TvShowManagerWPF.TvShowTracker.WebsiteLauncher;

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
        private readonly TvShowDownloaderViewModel showDownloader = new TvShowDownloaderViewModel();
        private readonly WebsiteLauncherViewModel websiteLauncher = new WebsiteLauncherViewModel();
        private bool isTvShowsChecked;
        private bool isTvShowsArchivedChecked;
        private bool isTvShowsPopularChecked;
        private bool isTvShowsTopRatedChecked;
        private bool isBackwardNavigationStackEmpty;
        private bool isForwardNavigationStackEmpty;
        private string textBoxSearchQuery;
        private bool isTvShowDownloaderChecked;
        private readonly NavigationStateService navigationService = new NavigationStateService();
        private Navigation currentNavigation;
        private bool isWebsiteLauncherChecked;

        public TvShowTrackerViewModel()
        {
            SearchCommand = new RelayCommand(OnSearchTvShows);
            ClearSearchCommand = new RelayCommand(ClearSearch);
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
            IsBackwardNavigationStackEmpty = navigationService.IsBackwardNavigationStackEmpty();
            IsForwardNavigationStackEmpty = navigationService.IsForwardNavigationStackEmpty();
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

        public bool IsTvShowDownloaderChecked
        {
            get { return isTvShowDownloaderChecked; }
            set { isTvShowDownloaderChecked = value; OnPropertyChanged(); }
        }

        public bool IsWebsiteLauncherChecked
        {
            get { return isWebsiteLauncherChecked; }
            set { isWebsiteLauncherChecked = value; OnPropertyChanged(); }
        }

        public bool IsBackwardNavigationStackEmpty
        {
            get { return isBackwardNavigationStackEmpty; }
            set { isBackwardNavigationStackEmpty = value; OnPropertyChanged(); }
        }

        public bool IsForwardNavigationStackEmpty
        {
            get { return isForwardNavigationStackEmpty; }
            set { isForwardNavigationStackEmpty = value; OnPropertyChanged(); }
        }

        public TvShowLatestNewsViewModel TvShowLatestNewsViewModel
        {
            get { return latestNews; }
            set { latestNews = value; OnPropertyChanged(); }
        }

        public string TextBoxSearchQuery
        {
            get { return textBoxSearchQuery; }
            set { textBoxSearchQuery = value; OnPropertyChanged(); }
        }

        public RelayCommand SearchCommand { get; private set; }
        public RelayCommand ClearSearchCommand { get; private set; }
        public RelayCommand<Navigation> NavigateCommand { get; private set; } 
        public RelayCommand NavigateForwardCommand { get; private set; } 
        public RelayCommand NavigateBackwardCommand { get; private set; } 

        public void OnNavigation(Navigation navigation)
        {
            switch (navigation)
            {
                case Navigation.TvShows:
                    if (currentNavigation != Navigation.TvShows)
                    {
                        CurrentViewModel = shows;
                        navigationService.AddNavigationState(new TvShowsNavigationState());
                    }
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
                    if (currentNavigation != Navigation.TvShowsArchived)
                    {
                        CurrentViewModel = archivedShows;
                        navigationService.AddNavigationState(new TvShowsArchivedNavigationState());
                    }
                    break;
                case Navigation.TvShowsPopular:
                    if (currentNavigation != Navigation.TvShowsPopular)
                    {
                        CurrentViewModel = popularShows;
                        navigationService.AddNavigationState(new TvShowsPopularNavigationState());
                    }
                    break;
                case Navigation.TvShowsTopRated:
                    if (currentNavigation != Navigation.TvShowsTopRated)
                    {
                        CurrentViewModel = topRatedShows;
                        navigationService.AddNavigationState(new TvShowsTopRatedNavigationState());
                    }
                    break;
                case Navigation.TvShowDownloader:
                    if (currentNavigation != Navigation.TvShowDownloader)
                    {
                        CurrentViewModel = showDownloader;
                        navigationService.AddNavigationState(new TvShowDownloaderNavigationState());
                    }
                    break;
                case Navigation.WebsiteLauncher:
                    if (currentNavigation != Navigation.WebsiteLauncher)
                    {
                        CurrentViewModel = websiteLauncher;
                        navigationService.AddNavigationState(new WebsiteLauncherNavigationState());
                    }
                    break;
            }

            currentNavigation = navigation;

            IsBackwardNavigationStackEmpty = navigationService.IsBackwardNavigationStackEmpty();
            IsForwardNavigationStackEmpty = navigationService.IsForwardNavigationStackEmpty();
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
                case Navigation.TvShowDownloader:
                    CurrentViewModel = showDownloader;
                    IsTvShowDownloaderChecked = true;
                    break;
                case Navigation.WebsiteLauncher:
                    CurrentViewModel = websiteLauncher;
                    IsWebsiteLauncherChecked = true;
                    break;
            }

            IsBackwardNavigationStackEmpty = navigationService.IsBackwardNavigationStackEmpty();
            IsForwardNavigationStackEmpty = navigationService.IsForwardNavigationStackEmpty();
        }

        public void NavigateForward()
        {
            OnHistoryNavigation(navigationService.NavigateForward());
        }

        public void NavigateBackward()
        {
            OnHistoryNavigation(navigationService.NavigateBackward());
        }

        public void OnXButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.XButton1 == MouseButtonState.Pressed)
            {
                NavigateBackward();
                e.Handled = true;
            }

            if (e.XButton2 == MouseButtonState.Pressed)
            {
                NavigateForward();
                e.Handled = true;
            }
        }

        private void SetCheckedStatusOnAllControls(bool status)
        {
            IsTvShowsChecked = status;
            IsTvShowsArchivedChecked = status;
            IsTvShowsPopularChecked = status;
            IsTvShowsTopRatedChecked = status;
            IsTvShowDownloaderChecked = status;
        }

        private void OnSearchTvShows()
        {
            searchedTvShows.TvShows = TvShowService.SearchTvShows(TextBoxSearchQuery, ConfigurationData.NoImageFoundPath).ToObservableCollection();
            searchedTvShows.SearchQuery = TextBoxSearchQuery;
            OnNavigation(Navigation.TvShowsSearched);
        }

        private void ClearSearch()
        {
            TextBoxSearchQuery = "";
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