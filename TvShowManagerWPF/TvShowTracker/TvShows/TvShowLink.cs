using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvShowManagerLibrary;

namespace TvShowManagerWPF.TvShowTracker.TvShows
{
    public class TvShowLink
    {
        public TvShow TvShow { get; set; }

        public RelayCommand OnHyperLinkNavigateCommand { get; private set; }

        public TvShowLink()
        {
            OnHyperLinkNavigateCommand = new RelayCommand(OnHyperLinkNavigate);
        }

        private void OnHyperLinkNavigate()
        {
            
        }
    }
}
