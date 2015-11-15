using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvShowManagerLibrary;

namespace TvShowManagerWPF.TvShowTracker.TvShowsSearched
{
    public class TvShowsSearchedViewModel : BaseViewModel
    {
        private ObservableCollection<TvShow> tvShows;
        private TvShow selectedTvShow;

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
                if (selectedTvShow != value)
                {
                    selectedTvShow = value;
                    OnPropertyChanged();
                    DisplayTvShowDetails();
                }
            }
        }

        public event Action<TvShow> DisplayTvShowDetailsRequested = delegate { };

        private void DisplayTvShowDetails()
        {
            DisplayTvShowDetailsRequested(SelectedTvShow);
        }
    }
}
