using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvShowManagerLibrary;
using TvShowManagerLibrary.Configurations;
using TvShowManagerLibrary.Services;

namespace TvShowManagerWPF.TvShowTracker.TvShowDetails
{
    public class TvShowDetailsViewModel : BaseViewModel
    {
        private TvShow tvShow;
        private string _subscribeButtonText;

        public RelayCommand SubscribeCommand { get; private set; }
        public event Action<TvShow> TvShowSubscriptionChanged = delegate { };

        public TvShowDetailsViewModel()
        {
            SubscribeButtonText = GetSubscribeButtonText();

            SubscribeCommand = new RelayCommand(ToggleSubscription);
        }

        public TvShow TvShow
        {
            get { return tvShow; }
            set
            {
                tvShow = value; OnPropertyChanged();
                SubscribeButtonText = GetSubscribeButtonText();
            }
        }

        public string SubscribeButtonText
        {
            get { return _subscribeButtonText; }
            set { _subscribeButtonText = value; OnPropertyChanged(); }
        }

        private string GetSubscribeButtonText()
        {
            if (TvShow == null)
                return "";

            return Service.IsSubscribing(TvShow) ? "Unsubscribe" : "Subscribe";
        }

        private void ToggleSubscription()
        {
            TvShowSubscriptionChanged(TvShow);
            SubscribeButtonText = GetSubscribeButtonText();
        }
    }
}
