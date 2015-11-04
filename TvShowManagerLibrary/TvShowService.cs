using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvShowManagerLibrary.ExternalServices;
using TvShowManagerLibrary.Repositories;

namespace TvShowManagerLibrary
{
    public class TvShowService
    {
        private readonly ITvShowExternalService<TvShow> service; 
        private readonly ITvShowRepository repository;

        /// <summary>
        /// Create a tv show service
        /// </summary>
        /// <param name="service">An external service for getting information about tv shows</param>
        /// <param name="repository">A tv show repository</param>
        public TvShowService(ITvShowExternalService<TvShow> service, ITvShowRepository repository)
        {
            this.service = service;
            this.repository = repository;
        }

        /// <summary>
        /// Searches tv shows from an external source based on a query
        /// </summary>
        /// <param name="query">The query</param>
        /// <returns>A list of tv shows based on the query</returns>
        public List<TvShow> SearchTvShows(string query)
        {
            return service.SearchTvShows(query);
        } 
        
        /// <summary>
        /// Checks if a user is already subscribing to the tv show
        /// </summary>
        /// <param name="show">The tv show to check</param>
        /// <returns>True if subscribing, false otherwise</returns>
        public bool IsSubscribing(TvShow show)
        {
            return repository.GetTvShow(show.ID) != null;
        }

        /// <summary>
        /// Start subscribing to a tv show
        /// </summary>
        /// <param name="show">The tv show to subscribe to</param>
        public void Subscribe(TvShow show)
        {
            repository.InsertTvShow(show);
            repository.Save();
        }

        /// <summary>
        /// Unsubscribe to a tv show
        /// </summary>
        /// <param name="show">The tv show to unsubscribe</param>
        public void Unsubscribe(TvShow show)
        {
            repository.RemoveTvShow(show.ID);
            repository.Save();
        }
    }
}
