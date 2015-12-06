using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary;

namespace WScrape
{
    public static class WScraper
    {
        public static WScrapeResult Scrape(string url, string beginTag, string endTag, string cacheFilePath)
        {
            var content = GetContent(url, cacheFilePath);

            return new WScrapeResult
            {
                Url = url,
                Content = content,
                Result = content.Split('\n')
                            .Where(x => x.Contains(beginTag))
                            .Select(x => x.FindSubstring(beginTag, endTag)).ToList()
            };
        }

        private static string GetContent(string url, string cacheFilePath)
        {
            try
            {
                using (var client = new WScrapeWebClient())
                {
                    var content = client.DownloadString(url);
                    File.WriteAllText(cacheFilePath, content);
                    return content;
                }
            }
            catch (WebException)
            {
                return File.Exists(cacheFilePath) ? File.ReadAllText(cacheFilePath) : string.Empty;
            }
        }
    }
}
