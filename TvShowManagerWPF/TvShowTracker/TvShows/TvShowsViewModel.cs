using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary;
using TvShowManagerLibrary;
using TvShowManagerLibrary.Configurations;
using TvShowManagerLibrary.Services;

namespace TvShowManagerWPF.TvShowTracker.TvShows
{
    public class TvShowsViewModel : BaseViewModel
    {
        private ObservableCollection<TvShow> tvShows;
        private TvShow selectedTvShow;

        public event Action<TvShow> DisplayTvShowDetailsRequested = delegate { };

        public TvShowsViewModel()
        {
            TvShows = Service.GetAllSubscribedTvShows().ToObservableCollection();
        }

        public ObservableCollection<TvShow> TvShows
        {
            get { return tvShows; }
            set { tvShows = value; OnPropertyChanged(); }
        }

        public TvShow SelectedTvShow
        {
            get { return selectedTvShow; }
            set
            {
                selectedTvShow = value;
                OnPropertyChanged();
                DisplayTvShowDetailsRequested(value);
            }
        }
    }
}
