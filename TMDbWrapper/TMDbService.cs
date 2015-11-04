using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return new List<TMDbTvShow>()
            {
                new TMDbTvShow() { ID = "1", Name = "Big Bang Theory", Overview = "Overview....Big Bang Theory" },
                new TMDbTvShow() { ID = "2", Name = "Breaking Bad", Overview = "Overview....Breaking Bad" },
                new TMDbTvShow() { ID = "3", Name = "Battlestar Galactica", Overview = "Overview....Battlestar Galactica" },
            };
        }
    }
}
