using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvShowManagerLibrary;

namespace TvShowManagerWPF.TvShowTracker.TvShowDetails
{
    public class TvShowDetailsViewModel : BaseViewModel
    {
        private TvShow tvShow;

        public TvShow TvShow
        {
            get { return tvShow; }
            set { tvShow = value; OnPropertyChanged(); }
        }
    }
}
