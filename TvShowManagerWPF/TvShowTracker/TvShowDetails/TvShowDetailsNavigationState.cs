using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvShowManagerLibrary;

namespace TvShowManagerWPF.TvShowTracker.TvShowDetails
{
    public class TvShowDetailsNavigationState : INavigationState
    {
        private readonly TvShowDetailsViewModel viewModel;
        private TvShow show;

        public TvShowDetailsNavigationState(TvShowDetailsViewModel viewModel)
        {
            this.viewModel = viewModel;
            Save();
        }

        public void Save()
        {
            if (viewModel.TvShow == null)
                return;

            show = viewModel.TvShow;
        }

        public void Load()
        {
            viewModel.TvShow = show;
        }

        public Navigation GetNavigation()
        {
            return Navigation.TvShowDetails;
        }
    }
}
