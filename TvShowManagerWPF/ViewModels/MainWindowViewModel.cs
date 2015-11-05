using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvShowManagerLibrary;
using TvShowManagerLibrary.Configurations;
using TvShowManagerLibrary.ExternalServices;
using TvShowManagerLibrary.Repositories;

namespace TvShowManagerWPF.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private readonly TvShowService service;

        private ObservableCollection<TvShow> tvShowSearchViewItems;
        private bool displayTvShowSearchView;
        private bool displayTvShowDetailsView;
        private TvShow tvShowDetailsViewItem;
        private string tvShowDetailsToggleSubscriptionText;

        public MainWindowViewModel()
        {
            var externalService = new TvShowTMDbExternalService(ConfigurationManager.Configuration.ApiKey);
            var repository = new TvShowXmlRepository(Configurations.SubscriptionsFilepath);
            
            service = new TvShowService(externalService, repository);
        }

        public ObservableCollection<TvShow> TvShowSearchViewItems
        {
            get { return tvShowSearchViewItems; }
            set { tvShowSearchViewItems = value; OnPropertyChanged(); }
        }

        public bool DisplayTvShowSearchView
        {
            get { return displayTvShowSearchView; }
            set { displayTvShowSearchView = value; OnPropertyChanged(); }
        }

        public void SearchTvShows(string query)
        {
            if (TvShowSearchViewItems == null)
                TvShowSearchViewItems = new ObservableCollection<TvShow>();

            TvShowSearchViewItems.Clear();
            service.SearchTvShows(query).ForEach(show => TvShowSearchViewItems.Add(show));
        }

        public bool DisplayTvShowDetailsView
        {
            get { return displayTvShowDetailsView; }
            set { displayTvShowDetailsView = value; OnPropertyChanged(); }
        }

        public TvShow TvShowDetailsViewItem
        {
            get { return tvShowDetailsViewItem; }
            set
            {
                tvShowDetailsViewItem = value;
                TvShowDetailsToggleSubscriptionText = GetTvShowDetailsToggleSubscriptionText(value);

                OnPropertyChanged();
            }
        }

        public void TvShowDetailsToggleSubscription(TvShow show)
        {
            if (service.IsSubscribing(show))
                service.Unsubscribe(show);
            else
                service.Subscribe(show);

            TvShowDetailsToggleSubscriptionText = GetTvShowDetailsToggleSubscriptionText(show);
        }

        public string TvShowDetailsToggleSubscriptionText
        {
            get { return tvShowDetailsToggleSubscriptionText; }
            set { tvShowDetailsToggleSubscriptionText = value; OnPropertyChanged(); }
        }

        private string GetTvShowDetailsToggleSubscriptionText(TvShow show)
        {
            return service.IsSubscribing(show) ? "Unsubscribe" : "Subscribe";
        }
    }
}
