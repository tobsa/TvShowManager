using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

        public RelayCommand<string> HyperLinkMultiCommand { get; private set; }

        public TvShowsViewModel()
        {
        }

        public TvShowsViewModel(TvShowService service)
        {
            TvShows = service.GetAllSubscribedTvShows().ToObservableCollection();
            HyperLinkMultiCommand = new RelayCommand<string>(HyperLinkMultiClicked);
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
            new ImageLink(ConfigurationData.SceneAccess, "../../Content/SceneAccessIcon.ico"),
            new ImageLink(ConfigurationData.Addic7ed, "../../Content/Addic7edIcon.ico"),
            new ImageLink(ConfigurationData.PirateBay, "../../Content/PirateBayIcon.ico"),
            new ImageLink(ConfigurationData.KickassTorrent, "../../Content/KickassTorrentIcon.ico"),
            new ImageLink(ConfigurationData.IMDb, "../../Content/ImdbIcon.ico"),
        };

        private void HyperLinkMultiClicked(string parameter)
        {
            var links = LinkManager.DeserializeLinks(ConfigurationData.LinksFilepath);
            var link = links.Single(x => x.Name == parameter);

            foreach (var show in TvShows)
            {
                switch (parameter)
                {
                    case ConfigurationData.SceneAccess:
                        if (GetName(show).HasValue())
                            Process.Start(new ProcessStartInfo(link.PreValue + GetName(show) + link.PostValue));
                        break;
                    case ConfigurationData.Addic7ed:
                        if (show.Addic7edID.HasValue())
                            Process.Start(new ProcessStartInfo(link.PreValue + show.Addic7edID + link.PostValue));
                        break;
                    case ConfigurationData.PirateBay:
                        if (GetName(show).HasValue())
                            Process.Start(new ProcessStartInfo(link.PreValue + GetName(show) + link.PostValue));
                        break;
                    case ConfigurationData.KickassTorrent:
                        if (GetName(show).HasValue())
                            Process.Start(new ProcessStartInfo(link.PreValue + GetName(show) + link.PostValue));
                        break;
                    case ConfigurationData.IMDb:
                        if (show.IMDbID.HasValue())
                            Process.Start(new ProcessStartInfo(link.PreValue + show.IMDbID + link.PostValue));
                        break;
                }
            }
        }

        private string GetName(TvShow show)
        {
            return show.CustomName.HasValue() ? show.CustomName : show.Name;
        }
    }
}
