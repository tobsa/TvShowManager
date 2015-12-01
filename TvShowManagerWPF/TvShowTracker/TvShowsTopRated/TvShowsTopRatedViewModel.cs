using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary;
using TvShowManagerLibrary;
using TvShowManagerLibrary.Services;

namespace TvShowManagerWPF.TvShowTracker.TvShowsTopRated
{
    public class TvShowsTopRatedViewModel : BaseViewModel
    {
        private ObservableCollection<TvShow> shows;


        public event Action<TvShow> DisplayTvShowDetailsRequested = delegate { };
        public RelayCommand<TvShow> OnDisplayTvShowDetailsCommand { get; private set; }

        public TvShowsTopRatedViewModel()
        {
            OnDisplayTvShowDetailsCommand = new RelayCommand<TvShow>(OnDisplayTvShowDetails);
        }

        public void LoadTvShows()
        {
            TvShows = TvShowService.GetTopRatedTvShows(ConfigurationData.NoImageFoundPath).ToObservableCollection();
        }

        public ObservableCollection<TvShow> TvShows
        {
            get { return shows; }
            set { shows = value; OnPropertyChanged(); }
        }

        private void OnDisplayTvShowDetails(TvShow show)
        {
            DisplayTvShowDetailsRequested(show);
        }
    }
}
