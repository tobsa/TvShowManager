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

namespace TvShowManagerWPF.TvShowTracker
{
    public class TvShowTrackerViewModel : BaseViewModel
    {
        #region Fields
        private readonly TvShowService service; 
        private TvShowsViewModel tvShowsViewModel = new TvShowsViewModel();
        private TvShowsSearchedViewModel tvShowsSearchedViewModel = new TvShowsSearchedViewModel();
        private TvShowDetailsViewModel tvShowDetailsViewModel = new TvShowDetailsViewModel();
        private bool isTabItemTvShowSearchedSelected;
        private bool isTabItemTvShowDetailsSelected;
        #endregion

        public TvShowTrackerViewModel()
        {
            service = TvShowServiceFactory.Create(ConfigurationManager.ApiKey, Filepaths.SubscriptionsFilepath);
            SearchCommand = new RelayCommand(SearchTvShows);
            tvShowsSearchedViewModel.DisplayTvShowDetailsRequested += DisplayTvShowDetails;
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
        #endregion  

        public RelayCommand SearchCommand { get; private set; }

        #region Methods
        private void SearchTvShows()
        {
            IsTabItemTvShowSearchedSelected = true;
            TvShowsSearchedViewModel.TvShows = service.SearchTvShows(TextBoxSearchQuery, Filepaths.NoImageFoundPath).ToObservableCollection();
        }

        private void DisplayTvShowDetails(TvShow show)
        {
            if (show != null)
            {
                TvShowDetailsViewModel.TvShow = show;
                IsTabItemTvShowDetailsSelected = true;
            }
        }
        #endregion
    }
}