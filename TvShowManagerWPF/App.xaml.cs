﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TvShowManagerLibrary.Configurations;

namespace TvShowManagerWPF
{
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            ConfigurationManager.Load(Configurations.ConfigurationFilePath);
        }
    }
}
