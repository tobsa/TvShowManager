using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvShowManagerLibrary.WebScrapers;

namespace TvShowManagerWPF.TvShowTracker.TvShowSubtitles
{
    public class TvShowSubtitlesViewModel : BaseViewModel
    {
        public TvShowSubtitlesViewModel()
        {
            var a = new Addic7edScraper();
            //a.GetLinks("http://www.addic7ed.com/log.php?mode=hotspot");
        }
    }
}
