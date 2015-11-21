using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using TvShowManagerLibrary.Configurations;
using TvShowManagerLibrary.Serialization;
using TvShowManagerLibrary.Services;
using WebScraper;

namespace TvShowManagerWPF
{
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            ConfigurationManager.Load(ConfigurationData.ConfigurationFilePath);

            WebScraperManager.CacheFilepath = ConfigurationData.Addic7edRequestCacheFilepath;
        }
    }
}
