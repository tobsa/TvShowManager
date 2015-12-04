using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary;
using TvShowManagerLibrary;

namespace TvShowManagerWPF.TvShowTracker.TvShows
{
    public class TvShowsNavigationState : INavigationState
    {
        public void Save()
        {
        }

        public void Load()
        {
        }

        public Navigation GetNavigation()
        {
            return Navigation.TvShows;
        }
    }
}
