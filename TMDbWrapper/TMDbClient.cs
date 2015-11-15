using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Deserializers;

namespace TMDbWrapper
{
    internal partial class TMDbClient
    {
        private const string BaseUrl = "http://api.themoviedb.org/3/";

        private readonly string apiKey;
        private readonly RestClient client;

        public TMDbClient(string apiKey)
        {
            this.apiKey = apiKey;

            client = new RestClient(BaseUrl);
            client.AddDefaultParameter("api_key", apiKey, ParameterType.QueryString);
            client.ClearHandlers();
            client.AddHandler("application/json", new JsonDeserializer());
        }
    }
}
