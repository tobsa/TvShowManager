using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvShowManagerLibrary.ExternalServices;
using TvShowManagerLibrary.Repositories;

namespace TvShowManagerLibrary.Services
{
    public static class TvShowServiceFactory
    {
        public static TvShowService Create(string apiKey, string filename)
        {
            var externalService = new TvShowTMDbExternalService(apiKey);
            var repository = new TvShowXmlRepository(filename);

            return new TvShowService(externalService, repository);
        }
    }
}
