using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using CoreLibrary;
using TvShowManagerLibrary;
using TvShowManagerLibrary.BrowserLauncher;
using TvShowManagerLibrary.Configurations;
using TvShowManagerLibrary.Services;

namespace TvShowManagerWPF.TvShowTracker.TvShows
{
    public class TvShowsViewModel : BaseViewModel
    {
        private readonly BrowserLauncher launcher;
        private ObservableCollection<TvShow> tvShows;
        private List<TvShowLink> _tvShowsCollectionView;

        public event Action<TvShow> DisplayTvShowDetailsRequested = delegate { };

        public RelayCommand<TvShow> OnDisplayTvShowDetailsCommand { get; private set; }
        public RelayCommand<TvShow> OnHyperLink1NavigateCommand { get; private set; }
        public RelayCommand<TvShow> OnHyperLink2NavigateCommand { get; private set; }
        public RelayCommand<TvShow> OnHyperLink3NavigateCommand { get; private set; }
        public RelayCommand<TvShow> OnHyperLink4NavigateCommand { get; private set; }
        public RelayCommand<TvShow> OnHyperLink5NavigateCommand { get; private set; }
        public RelayCommand<Websites> OnHyperLinkMultiNavigateCommand { get; private set; }

        public TvShowsViewModel()
        {
            launcher = new BrowserLauncher(ConfigurationData.LinksFilepath);
            OnDisplayTvShowDetailsCommand = new RelayCommand<TvShow>(OnDisplayTvShowDetails);

            OnHyperLink1NavigateCommand = new RelayCommand<TvShow>(OnHyperLink1Navigate);
            OnHyperLink2NavigateCommand = new RelayCommand<TvShow>(OnHyperLink2Navigate);
            OnHyperLink3NavigateCommand = new RelayCommand<TvShow>(OnHyperLink3Navigate);
            OnHyperLink4NavigateCommand = new RelayCommand<TvShow>(OnHyperLink4Navigate);
            OnHyperLink5NavigateCommand = new RelayCommand<TvShow>(OnHyperLink5Navigate);
            OnHyperLinkMultiNavigateCommand = new RelayCommand<Websites>(OnHyperLinkMultiNavigate);
        }

        private void LoadTvShowsCollectionView()
        {
            var links = TvShows.Select(x => new TvShowLink()
            {
                Name = x.Name,
                Addic7edLink = x.Addic7edID
            }).ToList();

            TvShowsCollectionView = links;
        }

        public List<TvShowLink> TvShowsCollectionView
        {
            get { return _tvShowsCollectionView; }
            set { _tvShowsCollectionView = value; OnPropertyChanged(); }
        }

        public void LoadTvShows()
        {
            TvShows = TvShowService.GetActiveTvShows().ToObservableCollection();
            LoadTvShowsCollectionView();
        }

        public ObservableCollection<TvShow> TvShows
        {
            get { return tvShows; }
            set
            {
                tvShows = value; OnPropertyChanged();
                LoadTvShowsCollectionView();
            }
        }
        
        private void OnDisplayTvShowDetails(TvShow show)
        {
            DisplayTvShowDetailsRequested(show);
        }

        private void OnHyperLinkMultiNavigate(Websites parameter)
        {
            foreach (var show in TvShows)
            {
                launcher.LaunchBrowser(show, parameter);
            }
        }

        private void OnHyperLink1Navigate(TvShow show)
        {
            launcher.LaunchBrowser(show, Websites.SceneAccess);
        }
        private void OnHyperLink2Navigate(TvShow show)
        {
            launcher.LaunchBrowser(show, Websites.Addic7ed);
        }
        private void OnHyperLink3Navigate(TvShow show)
        {
            launcher.LaunchBrowser(show, Websites.PirateBay);
        }
        private void OnHyperLink4Navigate(TvShow show)
        {
            launcher.LaunchBrowser(show, Websites.KickassTorrent);
        }
        private void OnHyperLink5Navigate(TvShow show)
        {
            launcher.LaunchBrowser(show, Websites.IMDb);
        }
    }
}
