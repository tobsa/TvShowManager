using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvShowManagerWPF.TvShowTracker.TvShows
{
    public class ImageLink
    {
        public ImageLink(string name, string link)
        {
            Name = name;
            Link = link;
        }

        public string Name { get; set; }
        public string Link { get; set; }
    }
}
