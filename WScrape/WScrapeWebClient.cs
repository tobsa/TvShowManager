using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WScrape
{
    public class WScrapeWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = (HttpWebRequest)base.GetWebRequest(address);
            if (request != null)
            {
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            }
            return request;
        }

        public void DownloadFileFromUrlToFile(string url, string file)
        {
            var request = GetWebRequest(new Uri(url));
            var response = GetWebResponse(request);

            var buffer = new byte[4096];
            var gzip = response.Headers["Content-Encoding"] == "gzip";
            var responseStream = gzip ? new GZipStream(response.GetResponseStream(), CompressionMode.Decompress)
                                      : response.GetResponseStream();

            using (var memoryStream = new MemoryStream())
            {
                var count = 0;
                do
                {
                    count = responseStream.Read(buffer, 0, buffer.Length);
                    memoryStream.Write(buffer, 0, count);
                } while (count != 0);

                var result = memoryStream.ToArray();

                using (var writer = new BinaryWriter(new FileStream(file, FileMode.Create)))
                {
                    writer.Write(result);
                }
            }
        }
    }
}
