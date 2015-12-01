using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary;
using TMDbWrapper.TV;
using TMDbWrapper.Utility;

namespace TMDbWrapper
{
    public class TMDbService
    {
        private readonly TMDbClient client;
        private const string BasePosterPath = "https://image.tmdb.org/t/p/";

        public TMDbService(string apiKey)
        {
            client = new TMDbClient(apiKey);
        }

        public List<TMDbTvShow> SearchTvShows(string query, PosterSize size = PosterSize.w500, string defaultPosterPath = "")
        {
            if (query.IsNullOrEmpty())
                return new List<TMDbTvShow>();

            var shows = client.SearchTvShows(query);

            foreach (var show in shows)
            {
                show.PosterPath = show.PosterPath.HasValue() ? BasePosterPath + size + show.PosterPath : defaultPosterPath;
            }

            return shows;
        }

        public TMDbTvShow GetTvShow(string id, PosterSize size = PosterSize.w500, string defaultPosterPath = "")
        {
            var show = client.GetTvShow(id);

            show.PosterPath = show.PosterPath.HasValue() ? BasePosterPath + size + show.PosterPath : defaultPosterPath;

            return show;
        }

        public List<TMDbTvShow> GetPopularTvShows(string defaultPosterPath = "", PosterSize size = PosterSize.w500)
        {
            var shows = client.GetPopularTvShows();

            foreach (var show in shows)
            {
                show.PosterPath = show.PosterPath.HasValue() ? BasePosterPath + size + show.PosterPath : defaultPosterPath;
            }

            return shows;
        }

        public List<TMDbTvShow> GetTopRatedTvShows(string defaultPosterPath = "", PosterSize size = PosterSize.w500)
        {
            var shows = client.GetTopRatedTvShows();

            foreach (var show in shows)
            {
                show.PosterPath = show.PosterPath.HasValue() ? BasePosterPath + size + show.PosterPath : defaultPosterPath;
            }

            return shows;
        }
    }
}
