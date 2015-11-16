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
        private readonly TvShowService service;
        private TvShow tvShow;
        private string subscribeButtonText;

        public RelayCommand SubscribeCommand { get; private set; }
        public event Action<TvShow> TvShowSubscriptionChanged = delegate { };

        public TvShowDetailsViewModel(TvShowService service)
        {
            this.service = service;

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
            get { return subscribeButtonText; }
            set { subscribeButtonText = value; OnPropertyChanged(); }
        }

        private string GetSubscribeButtonText()
        {
            if (TvShow == null)
                return "";

            return service.IsSubscribing(TvShow) ? "Unsubscribe" : "Subscribe";
        }

        private void ToggleSubscription()
        {
            TvShowSubscriptionChanged(TvShow);
            SubscribeButtonText = GetSubscribeButtonText();
        }
    }
}
