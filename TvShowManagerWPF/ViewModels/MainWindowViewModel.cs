using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvShowManagerLibrary;

namespace TvShowManagerWPF.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private TvShowService service = TvShowService.CreateXmlService();

        private ObservableCollection<TvShow> tvShowSearchViewItems;
        private bool displayTvShowSearchView;

        public ObservableCollection<TvShow> TvShowSearchViewItems
        {
            get
            {
                tvShowSearchViewItems = service.

                return tvShowSearchViewItems; 
            }
            set { tvShowSearchViewItems = value; OnPropertyChanged(); }
        }

        public bool DisplayTvShowSearchView
        {
            get { return displayTvShowSearchView; }
            set { displayTvShowSearchView = value; OnPropertyChanged(); }
        }
    }
}
