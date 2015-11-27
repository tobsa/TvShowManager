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
        private BaseViewModel _currentViewModel;
        private readonly TvShowTrackerViewModel tvShowTrackerViewModel = new TvShowTrackerViewModel();
        private TvShowViewerViewModel tvShowViewerViewModel = new TvShowViewerViewModel();

        public MainWindowViewModel()
        {
            CurrentViewModel = tvShowTrackerViewModel;
        }

        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set { _currentViewModel = value; OnPropertyChanged(); }
        }
    }
}
