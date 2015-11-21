using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary
{
    public static class HttpWebRequestExtensions
    {
        public static HttpWebResponse GetCustomResponse(this HttpWebRequest request)
        {
            try
            {
                return (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                if (ex.Response == null || ex.Status != WebExceptionStatus.ProtocolError)
                    throw;

                return (HttpWebResponse)ex.Response;
            }
        }
    }
}
