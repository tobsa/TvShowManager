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
        private string _customName;
        private string addic7edID;
        private string imdbID;
        private string saveButtonText;

        public RelayCommand SubscribeCommand { get; private set; }
        public RelayCommand SaveCustomDataCommand { get; private set; }

        public event Action<TvShow> TvShowSubscriptionChanged = delegate { };

        public TvShowDetailsViewModel()
        {
        }

        public TvShowDetailsViewModel(TvShowService service)
        {
            this.service = service;
            SubscribeButtonText = GetSubscribeButtonText();
            SaveButtonText = GetSaveButtonText();
            SubscribeCommand = new RelayCommand(ToggleSubscription);
            SaveCustomDataCommand = new RelayCommand(SaveCustomData);
        }

        public string CustomName
        {
            get { return _customName; }
            set
            {
                _customName = value;
                SaveButtonText = GetSaveButtonText();
                OnPropertyChanged();
            }
        }

        public string Addic7edID
        {
            get { return addic7edID; }
            set
            {
                addic7edID = value;
                SaveButtonText = GetSaveButtonText();
                OnPropertyChanged();
            }
        }

        public string IMDbID
        {
            get { return imdbID; }
            set
            {
                imdbID = value;
                SaveButtonText = GetSaveButtonText();
                OnPropertyChanged();
            }
        }

        public TvShow TvShow
        {
            get { return tvShow; }
            set
            {
                tvShow = value;
                CustomName = tvShow.CustomName;
                Addic7edID = tvShow.Addic7edID;
                IMDbID = tvShow.IMDbID;

                OnPropertyChanged();
                SubscribeButtonText = GetSubscribeButtonText();
                SaveButtonText = GetSaveButtonText();
            }
        }

        public string SubscribeButtonText
        {
            get { return subscribeButtonText; }
            set { subscribeButtonText = value; OnPropertyChanged(); }
        }

        public string SaveButtonText
        {
            get { return saveButtonText; }
            set { saveButtonText = value; OnPropertyChanged(); }
        }

        private string GetSubscribeButtonText()
        {
            if (TvShow == null)
                return "";

            return service.IsSubscribing(TvShow) ? "Unsubscribe" : "Subscribe";
        }

        private string GetSaveButtonText()
        {
            if (TvShow == null || (CustomName == TvShow.CustomName && Addic7edID == TvShow.Addic7edID && IMDbID == TvShow.IMDbID))
                return "Save";

            return "Save*";
        }

        private void ToggleSubscription()
        {
            TvShowSubscriptionChanged(TvShow);
            SubscribeButtonText = GetSubscribeButtonText();
        }

        private void SaveCustomData()
        {
            TvShow.CustomName = CustomName;
            TvShow.Addic7edID = Addic7edID;
            TvShow.IMDbID = IMDbID;
            SaveButtonText = GetSaveButtonText();

            service.UpdateTvShow(TvShow);
        }
    }
}
