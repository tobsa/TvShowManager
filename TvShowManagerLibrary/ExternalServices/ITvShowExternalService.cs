using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDbWrapper.Utility;

namespace TvShowManagerLibrary.ExternalServices
{
    /// <summary>
    /// Interface for getting tv show information from an external source (i.e. a REST api or similar...)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITvShowExternalService<T>
    {
        List<T> SearchTvShows(string query, string defaultPosterPath = "", PosterSize size = PosterSize.w500);
    }
}
