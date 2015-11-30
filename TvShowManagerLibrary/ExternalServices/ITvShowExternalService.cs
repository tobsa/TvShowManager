using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDbWrapper.Utility;

namespace TvShowManagerLibrary.ExternalServices
{
    public interface ITvShowExternalService<T>
    {
        List<T> SearchTvShows(string query, string defaultPosterPath = "", PosterSize size = PosterSize.w500);
        List<T> GetPopularTvShows(string defaultPosterPath = "", PosterSize size = PosterSize.w500);
    }
}
