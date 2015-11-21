using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper
{
    public interface IWebScraperMapper<T>
    {
        List<T> Map(WebScraperResult result);
    }
}
