using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvShowManagerLibrary
{
    public class TvShow : ICloneable
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public string BackdropPath { get; set; }
        public string CustomName { get; set; }
        public string IMDbID { get; set; }
        public string Addic7edID { get; set; }
        public bool IsArchived { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
