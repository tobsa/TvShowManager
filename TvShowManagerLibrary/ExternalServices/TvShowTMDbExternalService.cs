using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDbWrapper;
using TMDbWrapper.Utility;

namespace TvShowManagerLibrary.ExternalServices
{
    public class TvShowTMDbExternalService : ITvShowExternalService<TvShow>
    {
        private readonly TMDbService service;

        public TvShowTMDbExternalService(string apiKey)
        {
            service = new TMDbService(apiKey);
        }

        public List<TvShow> SearchTvShows(string query, string defaultPosterPath, PosterSize size = PosterSize.w500)
        {
            var shows = service.SearchTvShows(query, PosterSize.w500, defaultPosterPath);

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
