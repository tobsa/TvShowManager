using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Deserializers;

namespace TMDbWrapper.TV
{
    public class TMDbTvShow
    {
        [DeserializeAs(Name = "id")]
        public string ID { get; set; }

        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "overview")]
        public string Overview { get; set; }

        [DeserializeAs(Name = "poster_path")]
        public string PosterPath { get; set; }

        [DeserializeAs(Name = "backdrop_path")]
        public string BackdropPath { get; set; }
    }
}
