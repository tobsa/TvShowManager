using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvShowManagerLibrary.Configurations;
using TvShowManagerLibrary.Services;
using TvShowManagerWPF.TvShowTracker;
using TvShowManagerWPF.TvShowViewer;

namespace TvShowManagerWPF
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly TvShowService service;
        private TvShowTrackerViewModel tvShowTrackerViewModel;

        public MainWindowViewModel()
        {
            service = TvShowServiceFactory.Create(ConfigurationManager.ApiKey, ConfigurationData.SubscriptionsFilepath);
            tvShowTrackerViewModel = new TvShowTrackerViewModel(service);
        }

        public TvShowTrackerViewModel TvShowTrackerViewModel
        {
            get { return tvShowTrackerViewModel; }
            set { tvShowTrackerViewModel = value; OnPropertyChanged(); }
        }
    }
}
