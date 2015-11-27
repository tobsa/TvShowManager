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
        public static void CreateTvShowService(string apiKey, string filename)
        {
            TvShowService.Service = new TvShowTMDbExternalService(apiKey);
            TvShowService.Repository = new TvShowXmlRepository(filename);
        }
    }
}
