using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvShowManagerLibrary;
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

        public MainWindowViewModel()
        {
            var externalService = new TvShowTMDbExternalService("12345");
            var repository = new TvShowXmlRepository("Data/Subscriptions.xml");
            
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
            set { tvShowDetailsViewItem = value; OnPropertyChanged(); }
        }
    }
}
