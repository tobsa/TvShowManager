using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary;
using TMDbWrapper.TV;

namespace TMDbWrapper
{
    public class TMDbService
    {
        public TMDbService(string apiKey)
        {

        }

        public List<TMDbTvShow> SearchTvShows(string query)
        {
            const string f = @"F:\Tobias\Programming\Software\TvShowManager\TvShowManagerWPF\Content\NoImageFound.png";

            if (query.IsNullOrEmpty())
            {
                return new List<TMDbTvShow>()
                {
                    new TMDbTvShow() {ID = "1", Name = "Big Bang Theory", Overview = "Overview....Big Bang Theory", PosterPath = f},
                    new TMDbTvShow() {ID = "2", Name = "Breaking Bad", Overview = "Overview....Breaking Bad", PosterPath = f},
                    new TMDbTvShow() {ID = "3", Name = "Battlestar Galactica", Overview = "Overview....Battlestar Galactica",  PosterPath = f},
                };
            }

            return new List<TMDbTvShow>()
            {
                new TMDbTvShow() {ID = "4", Name = query, Overview = "Overview..." + query},
            };
        }
    }
}
