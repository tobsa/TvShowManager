using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDbWrapper;
using TMDbWrapper.TV;
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
            return shows.Select(Map).ToList();
        }

        public List<TvShow> GetPopularTvShows(string defaultPosterPath, PosterSize size = PosterSize.w500)
        {
            var shows = service.GetPopularTvShows(defaultPosterPath, size);
            return shows.Select(Map).ToList();
        }

        public List<TvShow> GetTopRatedTvShows(string defaultPosterPath, PosterSize size = PosterSize.w500)
        {
            var shows = service.GetTopRatedTvShows(defaultPosterPath, size);
            return shows.Select(Map).ToList();
        }

        private static TvShow Map(TMDbTvShow show)
        {
            return new TvShow()
            {
                ID = show.ID,
                Name = show.Name,
                Overview = show.Overview,
                PosterPath = show.PosterPath,
                BackdropPath = show.BackdropPath
            };
        }
    }
}
