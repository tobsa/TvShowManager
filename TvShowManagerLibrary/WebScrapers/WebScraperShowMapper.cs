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
            return result.Result.Select(x => new WebScraperShow()
            {
                SeriesName = x.FindSubstring("/", "/")
            }).ToList();
        }
    }
}
