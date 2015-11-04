using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvShowManagerLibrary.Repositories
{
    /// <summary>
    /// Base repository for tv shows
    /// </summary>
    public interface ITvShowRepository
    {
        void InsertTvShow(TvShow show);
        void UpdateTvShow(TvShow show);
        void RemoveTvShow(string id);
        TvShow GetTvShow(string id);
        List<TvShow> GetTvShows();
        void Save();
    }
}
