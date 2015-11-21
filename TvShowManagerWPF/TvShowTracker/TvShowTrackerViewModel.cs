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

namespace TvShowManagerWPF.TvShowTracker
{
    public class TvShowTrackerViewModel : BaseViewModel
    {
        #region Fields
        private readonly TvShowService service;
        private TvShowsViewModel tvShowsViewModel;
        private TvShowsSearchedViewModel tvShowsSearchedViewModel;
        private TvShowDetailsViewModel tvShowDetailsViewModel;
        private bool isTabItemTvShowSearchedSelected;
        private bool isTabItemTvShowDetailsSelected;
        private TvShowLatestNewsViewModel tvShowLatestNewsViewModel;
        #endregion

        public TvShowTrackerViewModel()
        {
        }

        public TvShowTrackerViewModel(TvShowService service)
        {
            this.service = service;
            tvShowsViewModel = new TvShowsViewModel(service);
            tvShowsSearchedViewModel = new TvShowsSearchedViewModel();
            tvShowDetailsViewModel = new TvShowDetailsViewModel(service);
            tvShowLatestNewsViewModel = new TvShowLatestNewsViewModel();

            SearchCommand = new RelayCommand(SearchTvShows);

            TvShowsSearchedViewModel.DisplayTvShowDetailsRequested += DisplayTvShowDetails;
            TvShowsViewModel.DisplayTvShowDetailsRequested += DisplayTvShowDetails;
            TvShowDetailsViewModel.TvShowSubscriptionChanged += TvShowSubscriptionChanged;
        }

        #region Properties
        public TvShowsViewModel TvShowsViewModel
        {
            get { return tvShowsViewModel; }
            set { tvShowsViewModel = value; OnPropertyChanged(); }
        }

        public TvShowsSearchedViewModel TvShowsSearchedViewModel
        {
            get { return tvShowsSearchedViewModel; }
            set { tvShowsSearchedViewModel = value; OnPropertyChanged(); }
        }

        public TvShowDetailsViewModel TvShowDetailsViewModel
        {
            get { return tvShowDetailsViewModel; }
            set { tvShowDetailsViewModel = value; OnPropertyChanged(); }
        }

        public bool IsTabItemTvShowSearchedSelected
        {
            get { return isTabItemTvShowSearchedSelected; }
            set { isTabItemTvShowSearchedSelected = value; OnPropertyChanged(); }
        }

        public bool IsTabItemTvShowDetailsSelected
        {
            get { return isTabItemTvShowDetailsSelected; }
            set { isTabItemTvShowDetailsSelected = value; OnPropertyChanged(); }
        }

        public string TextBoxSearchQuery { get; set; }

        public TvShowLatestNewsViewModel TvShowLatestNewsViewModel
        {
            get { return tvShowLatestNewsViewModel; }
            set { tvShowLatestNewsViewModel = value; OnPropertyChanged(); }
        }
        #endregion  

        public RelayCommand SearchCommand { get; private set; }

        #region Methods
        private void SearchTvShows()
        {
            IsTabItemTvShowSearchedSelected = true;
            TvShowsSearchedViewModel.TvShows = service.SearchTvShows(TextBoxSearchQuery, ConfigurationData.NoImageFoundPath).ToObservableCollection();
        }

        private void DisplayTvShowDetails(TvShow show)
        {
            if (show != null)
            {
                TvShowDetailsViewModel.TvShow = show;
                IsTabItemTvShowDetailsSelected = true;
            }
        }

        private void TvShowSubscriptionChanged(TvShow show)
        {
            if (show == null)
                return;

            if (service.IsSubscribing(show))
                service.Unsubscribe(show);
            else
                service.Subscribe(show);

            TvShowDetailsViewModel.TvShow = show;
            TvShowsViewModel.TvShows = service.GetAllSubscribedTvShows().ToObservableCollection();
        }
        #endregion
    }
}