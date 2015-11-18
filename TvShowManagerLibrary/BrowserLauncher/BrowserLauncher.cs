using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary;
using TvShowManagerLibrary.Configurations;

namespace TvShowManagerLibrary.BrowserLauncher
{
    public class BrowserLauncher
    {
        private readonly List<Link> links;

        public const string SceneAccess = "SceneAccess";
        public const string Addic7ed = "Addic7ed";
        public const string PirateBay = "PirateBay";
        public const string KickassTorrent = "KickassTorrent";
        public const string IMDb = "IMDb";

        public BrowserLauncher(string filepath)
        {
            links = LinkManager.DeserializeLinks(filepath);
        }

        public void LaunchBrowser(TvShow show, string parameter)
        {
            var link = links.Single(x => x.Name == parameter);

            switch (parameter)
            {
                case SceneAccess:
                    if (GetName(show).HasValue())
                        Process.Start(new ProcessStartInfo(link.PreValue + GetName(show) + link.PostValue));
                    break;
                case Addic7ed:
                    if (show.Addic7edID.HasValue())
                        Process.Start(new ProcessStartInfo(link.PreValue + show.Addic7edID + link.PostValue));
                    break;
                case PirateBay:
                    if (GetName(show).HasValue())
                        Process.Start(new ProcessStartInfo(link.PreValue + GetName(show) + link.PostValue));
                    break;
                case KickassTorrent:
                    if (GetName(show).HasValue())
                        Process.Start(new ProcessStartInfo(link.PreValue + GetName(show) + link.PostValue));
                    break;
                case IMDb:
                    if (show.IMDbID.HasValue())
                        Process.Start(new ProcessStartInfo(link.PreValue + show.IMDbID + link.PostValue));
                    break;
            }
        }

        private static string GetName(TvShow show)
        {
            return show.CustomName.HasValue() ? show.CustomName : show.Name;
        }
    }
}
