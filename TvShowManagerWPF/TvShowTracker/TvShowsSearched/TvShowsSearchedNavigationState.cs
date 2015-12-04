using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvShowManagerLibrary;

namespace TvShowManagerWPF.TvShowTracker.TvShowsSearched
{
    public class TvShowsSearchedNavigationState : INavigationState
    {
        private readonly TvShowsSearchedViewModel viewModel;
        private ObservableCollection<TvShow> shows;
        private string searchQuery;

        public TvShowsSearchedNavigationState(TvShowsSearchedViewModel viewModel)
        {
            this.viewModel = viewModel;
            Save();
        } 

        public void Save()
        {
            shows = viewModel.TvShows;
            searchQuery = viewModel.SearchQuery;
        }

        public void Load()
        {
            viewModel.TvShows = shows;
            viewModel.SearchQuery = searchQuery;
        }

        public Navigation GetNavigation()
        {
            return Navigation.TvShowsSearched;
        }
    }
}
