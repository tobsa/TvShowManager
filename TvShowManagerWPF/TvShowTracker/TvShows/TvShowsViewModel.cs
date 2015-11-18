using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary;
using TvShowManagerLibrary;
using TvShowManagerLibrary.BrowserLauncher;
using TvShowManagerLibrary.Configurations;
using TvShowManagerLibrary.Services;

namespace TvShowManagerWPF.TvShowTracker.TvShows
{
    public class TvShowsViewModel : BaseViewModel
    {
        private BrowserLauncher launcher;
        private ObservableCollection<TvShow> tvShows;
        private TvShow selectedTvShow;

        public event Action<TvShow> DisplayTvShowDetailsRequested = delegate { };

        public RelayCommand<TvShow> OnHyperLink1NavigateCommand { get; private set; }
        public RelayCommand<TvShow> OnHyperLink2NavigateCommand { get; private set; }
        public RelayCommand<TvShow> OnHyperLink3NavigateCommand { get; private set; }
        public RelayCommand<TvShow> OnHyperLink4NavigateCommand { get; private set; }
        public RelayCommand<TvShow> OnHyperLink5NavigateCommand { get; private set; }
        public RelayCommand<string> OnHyperLinkMultiNavigateCommand { get; private set; }


        public TvShowsViewModel()
        {
        }

        public TvShowsViewModel(TvShowService service)
        {
            launcher = new BrowserLauncher(ConfigurationData.LinksFilepath);
            TvShows = service.GetAllSubscribedTvShows().ToObservableCollection();
            OnHyperLink1NavigateCommand = new RelayCommand<TvShow>(OnHyperLink1Navigate);
            OnHyperLink2NavigateCommand = new RelayCommand<TvShow>(OnHyperLink2Navigate);
            OnHyperLink3NavigateCommand = new RelayCommand<TvShow>(OnHyperLink3Navigate);
            OnHyperLink4NavigateCommand = new RelayCommand<TvShow>(OnHyperLink4Navigate);
            OnHyperLink5NavigateCommand = new RelayCommand<TvShow>(OnHyperLink5Navigate);
            OnHyperLinkMultiNavigateCommand = new RelayCommand<string>(OnHyperLinkMultiNavigate);
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

        public List<ImageLink> ImagePaths => new List<ImageLink>()
        {
            new ImageLink(BrowserLauncher.SceneAccess, ConfigurationData.SceneAccessIcon),
            new ImageLink(BrowserLauncher.Addic7ed, ConfigurationData.Addic7edIcon),
            new ImageLink(BrowserLauncher.PirateBay, ConfigurationData.PirateBayIcon),
            new ImageLink(BrowserLauncher.KickassTorrent, ConfigurationData.KickassTorrentIcon),
            new ImageLink(BrowserLauncher.IMDb, ConfigurationData.IMDbIcon),
        };

        private void OnHyperLinkMultiNavigate(string parameter)
        {
            foreach (var show in TvShows)
            {
                launcher.LaunchBrowser(show, parameter);
            }
        }

        private void OnHyperLink1Navigate(TvShow show)
        {
            launcher.LaunchBrowser(show, BrowserLauncher.SceneAccess);
        }
        private void OnHyperLink2Navigate(TvShow show)
        {
            launcher.LaunchBrowser(show, BrowserLauncher.Addic7ed);
        }
        private void OnHyperLink3Navigate(TvShow show)
        {
            launcher.LaunchBrowser(show, BrowserLauncher.PirateBay);
        }
        private void OnHyperLink4Navigate(TvShow show)
        {
            launcher.LaunchBrowser(show, BrowserLauncher.KickassTorrent);
        }
        private void OnHyperLink5Navigate(TvShow show)
        {
            launcher.LaunchBrowser(show, BrowserLauncher.IMDb);
        }
    }
}
