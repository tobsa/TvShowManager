using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvShowManagerLibrary.ExternalServices;
using TvShowManagerLibrary.Repositories;

namespace TvShowManagerLibrary.Services
{
    public static class TvShowService
    {
        public static ITvShowExternalService<TvShow> Service { get; set; }
        public static ITvShowRepository Repository { get; set; }

        public static List<TvShow> SearchTvShows(string query, string defaultPosterPath = "")
        {
            return Service.SearchTvShows(query, defaultPosterPath);
        }
        
        public static bool IsSubscribing(TvShow show)
        {
            if (show == null)
                return false;

            return Repository.GetTvShow(show.ID) != null;
        }

        public static void Subscribe(TvShow show)
        {
            Repository.InsertTvShow(show);
            Repository.Save();
        }

        public static void Unsubscribe(TvShow show)
        {
            Repository.RemoveTvShow(show.ID);
            Repository.Save();
        }

        public static List<TvShow> GetAllSubscribedTvShows()
        {
            return Repository.GetTvShows();
        }

        public static List<TvShow> GetActiveTvShows()
        {
            return Repository.GetTvShows().Where(show => !show.IsArchived).ToList();
        }

        public static List<TvShow> GetArchivedTvShows()
        { 
            return Repository.GetTvShows().Where(show => show.IsArchived).ToList();
        }

        public static void UpdateTvShow(TvShow show)
        {
            Repository.UpdateTvShow(show);
            Repository.Save();
        }
    }
}
