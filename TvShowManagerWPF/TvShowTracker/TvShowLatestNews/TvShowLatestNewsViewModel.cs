using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary;
using TvShowManagerLibrary.BrowserLauncher;
using TvShowManagerLibrary.WebScrapers;
using WebScraper;

namespace TvShowManagerWPF.TvShowTracker.TvShowLatestNews
{
    public class TvShowLatestNewsViewModel : BaseViewModel
    {
        private const string Uri = "http://www.addic7ed.com/log.php?mode=hotspot";
        private const string BaseUri = "http://www.addic7ed.com/serie";

        private ObservableCollection<WebScraperShow> shows;

        public RelayCommand<WebScraperShow> OnOpenLinkCommand { get; set; }

        public TvShowLatestNewsViewModel()
        {
        }

        public TvShowLatestNewsViewModel(string ignored)
        {
            OnOpenLinkCommand = new RelayCommand<WebScraperShow>(OnOpenLink);

            var result = WebScraperManager.Scrape(new WebScraperUri() { BaseUri = BaseUri, Uri = Uri, BeginTag = "href=\"serie", EndTag = "\"" });
            Shows = WebScraperManager.Map<WebScraperShow, WebScraperShowMapper>(result).ToObservableCollection();
        }

        public ObservableCollection<WebScraperShow> Shows
        {
            get { return shows; }
            set { shows = value; OnPropertyChanged(); }
        }

        private static void OnOpenLink(WebScraperShow show)
        {
            Process.Start(new ProcessStartInfo(show.Uri));
        }
    }
}
