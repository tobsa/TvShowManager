using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary;

namespace WebScraper
{ 
    public class WebScraperManager
    {
        public static WebScraperResult Scrape(WebScraperUri uri)
        {
            using (var client = new WebClient())
            {
                var content = client.DownloadString(uri.Uri);

                return new WebScraperResult
                {
                    Uri = uri,
                    Content = content,
                    Result = content.Split('\n')
                            .Where(x => x.Contains(uri.BeginTag))
                            .Select(x => x.FindSubstring(uri.BeginTag, uri.EndTag)).ToList()
                };
            }
        }

        public static List<T> Map<T, TK>(WebScraperResult result) where TK : IWebScraperMapper<T>, new()
        {
            var mapper = new TK();
            return mapper.Map(result);
        }  
    }
}
