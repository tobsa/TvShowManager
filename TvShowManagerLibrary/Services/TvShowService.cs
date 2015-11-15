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
    public class TvShowService
    {
        private readonly ITvShowExternalService<TvShow> service; 
        private readonly ITvShowRepository repository;

        public TvShowService(ITvShowExternalService<TvShow> service, ITvShowRepository repository)
        {
            this.service = service;
            this.repository = repository;
        }

        public List<TvShow> SearchTvShows(string query, string defaultPosterPath = "")
        {
            return service.SearchTvShows(query, defaultPosterPath);
        }
        
        public bool IsSubscribing(TvShow show)
        {
            if (show == null)
                return false;

            return repository.GetTvShow(show.ID) != null;
        }

        public void Subscribe(TvShow show)
        {
            repository.InsertTvShow(show);
            repository.Save();
        }

        public void Unsubscribe(TvShow show)
        {
            repository.RemoveTvShow(show.ID);
            repository.Save();
        }

        public List<TvShow> GetAllSubscribedTvShows()
        {
            return repository.GetTvShows();
        }

        public void UpdateTvShow(TvShow show)
        {
            repository.UpdateTvShow(show);
            repository.Save();
        }
    }
}
