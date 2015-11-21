using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary;
using TvShowManagerLibrary.WebScrapers;
using WebScraper;

namespace TvShowManagerWPF.TvShowTracker.TvShowLatestNews
{
    public class TvShowLatestNewsViewModel : BaseViewModel
    {
        private const string BaseURI = "http://www.addic7ed.com/log.php?mode=hotspot";

        private ObservableCollection<WebScraperShow> shows;

        public TvShowLatestNewsViewModel()
        {
            var result = WebScraperManager.Scrape(new WebScraperUri() {Uri = BaseURI, BeginTag = "href=\"serie", EndTag = "</a"});

            Shows = WebScraperManager.Map<WebScraperShow, WebScraperShowMapper>(result).ToObservableCollection();
        }

        public ObservableCollection<WebScraperShow> Shows
        {
            get { return shows; }
            set { shows = value; OnPropertyChanged(); }
        }
    }
}
