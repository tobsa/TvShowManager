using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary;
using WebScraper;

namespace TvShowManagerLibrary.WebScrapers
{
    public class WebScraperShowMapper : IWebScraperMapper<WebScraperShow>
    {
        public List<WebScraperShow> Map(WebScraperResult result)
        {
            return result.Result.Select(x => Map(x, result.Uri)).ToList();
        }

        private static WebScraperShow Map(string result, WebScraperUri uri)
        {
            return new WebScraperShow()
            {
                Uri = uri.BaseUri + result,
                SeriesName = result.SliceIndexOfNth("/", 1, 2).TrimStart('/'),
                Season = result.SliceIndexOfNth("/", 2, 3).TrimStart('/'),
                Episode = result.SliceIndexOfNth("/", 3, 4).TrimStart('/'),
            };
        }
    }
}
