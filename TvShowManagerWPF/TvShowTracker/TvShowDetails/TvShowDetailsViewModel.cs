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
        private string subscribeButtonText;
        private string customName;
        private string addic7edID;
        private string imdbID;
        private string saveButtonText;
        private bool isSubscribing;
        private string archiveButtonText;

        public RelayCommand SubscribeCommand { get; private set; }
        public RelayCommand ArchiveCommand { get; private set; }
        public RelayCommand SaveCustomDataCommand { get; private set; }

        public event Action<TvShow> TvShowSubscriptionChanged = delegate { };
        public event Action<TvShow> TvShowArchiveChanged = delegate { };

        public TvShowDetailsViewModel()
        {
            SubscribeCommand = new RelayCommand(ToggleSubscription);
            ArchiveCommand = new RelayCommand(ToggleArchive);
            SaveCustomDataCommand = new RelayCommand(SaveCustomData);
        }

        public void LoadTexts()
        {
            SubscribeButtonText = GetSubscribeButtonText();
            SaveButtonText = GetSaveButtonText();
            ArchiveButtonText = GetArchiveButtonText();
        }

        public string CustomName
        {
            get { return customName; }
            set
            {
                customName = value;
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
                IsSubscribing = TvShowService.IsSubscribing(value);
                ArchiveButtonText = GetArchiveButtonText();
            }
        }

        public bool IsSubscribing
        {
            get { return isSubscribing; }
            set { isSubscribing = value; OnPropertyChanged(); }
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

        public string ArchiveButtonText
        {
            get { return archiveButtonText; }
            set { archiveButtonText = value; OnPropertyChanged(); }
        }

        private string GetSubscribeButtonText()
        {
            if (TvShow == null)
                return "";

            return TvShowService.IsSubscribing(TvShow) ? "Unsubscribe" : "Subscribe";
        }

        private string GetSaveButtonText()
        {
            if (TvShow == null || (CustomName == TvShow.CustomName && Addic7edID == TvShow.Addic7edID && IMDbID == TvShow.IMDbID))
                return "Save";

            return "Save*";
        }

        private string GetArchiveButtonText()
        {
            if (TvShow == null || TvShow.IsArchived)
                return "Activate";

            return "Archive";
        }

        private void ToggleSubscription()
        {
            TvShowSubscriptionChanged(TvShow);
            SubscribeButtonText = GetSubscribeButtonText();
            IsSubscribing = TvShowService.IsSubscribing(TvShow);
            ArchiveButtonText = GetArchiveButtonText();
        }

        private void ToggleArchive()
        {
            TvShow.IsArchived = !TvShow.IsArchived;
            TvShowService.UpdateTvShow(TvShow);
            ArchiveButtonText = GetArchiveButtonText();
            TvShowArchiveChanged(TvShow);
        }

        private void SaveCustomData()
        {
            if (TvShow.CustomName == CustomName && TvShow.Addic7edID == Addic7edID && TvShow.IMDbID == IMDbID)
                return;

            TvShow.CustomName = CustomName;
            TvShow.Addic7edID = Addic7edID;
            TvShow.IMDbID = IMDbID;
            SaveButtonText = GetSaveButtonText();

            TvShowService.UpdateTvShow(TvShow);
        }
    }
}
