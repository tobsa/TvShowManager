using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDbWrapper;

namespace TvShowManagerLibrary.ExternalServices
{
    public class TvShowTMDbExternalService : ITvShowExternalService<TvShow>
    {
        private readonly TMDbService service;

        public TvShowTMDbExternalService(string apiKey)
        {
            service = new TMDbService(apiKey);
        }

        public List<TvShow> SearchTvShows(string query)
        {
            var shows = service.SearchTvShows(query);

            return shows.Select(show => new TvShow()
            {
                ID = show.ID,
                Name = show.Name,
                Overview = show.Overview,
                PosterPath = show.PosterPath,
                BackdropPath = show.BackdropPath
            }).ToList();
        }
    }
}
