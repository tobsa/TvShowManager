using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvShowManagerLibrary.Serialization;

namespace TvShowManagerLibrary.Repositories
{
    public class TvShowXmlRepository : ITvShowRepository
    {
        private readonly List<TvShow> shows;
        private readonly string filename;

        public TvShowXmlRepository(string filename)
        {
            this.filename = filename;
            shows = XmlSerializerHelper.Deserialize<List<TvShow>>(filename) ?? new List<TvShow>();
        }

        public void InsertTvShow(TvShow show)
        {
            shows.Add(show);
        }

        public void UpdateTvShow(TvShow show)
        {
            throw new NotImplementedException();
        }

        public void RemoveTvShow(string id)
        {
            shows.RemoveAll(x => x.ID == id);
        }

        public TvShow GetTvShow(string id)
        {
            return shows.FirstOrDefault(show => show.ID == id);
        }

        public List<TvShow> GetTvShows()
        {
            return shows;
        }

        public void Save()
        {
            XmlSerializerHelper.Serialize(shows, filename);
        }
    }
}
