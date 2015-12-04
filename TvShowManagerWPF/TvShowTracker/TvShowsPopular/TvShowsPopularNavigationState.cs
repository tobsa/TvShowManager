using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvShowManagerWPF.TvShowTracker.TvShowsPopular
{
    public class TvShowsPopularNavigationState : INavigationState
    {
        public void Save()
        {
        }

        public void Load()
        {
        }

        public Navigation GetNavigation()
        {
            return Navigation.TvShowsPopular;
        }
    }
}
