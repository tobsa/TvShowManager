using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Deserializers;
using TMDbWrapper.TV;

namespace TMDbWrapper
{
    internal partial class TMDbClient
    {
        public List<TMDbTvShow> SearchTvShows(string query)
        {
            var request = new RestRequest("search/tv");
            request.AddParameter("query", query);

            return client.Get<TmdbTvShowSearchResult>(request).Data.TvShows;
        }

        public TMDbTvShow GetTvShow(string id)
        {
            var request = new RestRequest("tv/{id}?");
            request.AddUrlSegment("id", id);

            return client.Get<TMDbTvShow>(request).Data;
        }

        public string GetIMDbID(string id)
        {
            var request = new RestRequest("tv/{id}/external_ids");
            request.AddUrlSegment("id", id);

            return client.Get<ExternalIDs>(request).Data.IMDbID;
        }

        private class TmdbTvShowSearchResult
        {
            [DeserializeAs(Name = "results")]
            public List<TMDbTvShow> TvShows { get; set; }
        }

        private class ExternalIDs
        {
            [DeserializeAs(Name = "imdb_id")]
            public string IMDbID { get; set; }
        }
    }
}
