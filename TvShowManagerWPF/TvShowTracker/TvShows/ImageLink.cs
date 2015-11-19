using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvShowManagerLibrary;

namespace TvShowManagerWPF.TvShowTracker.TvShows
{
    public class ImageLink
    {
        public ImageLink(Websites name, string link)
        {
            Name = name;
            Link = link;
        }

        public Websites Name { get; set; }
        public string Link { get; set; }
    }
}
