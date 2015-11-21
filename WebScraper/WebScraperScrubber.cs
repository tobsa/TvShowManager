using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper
{
    public class WebScraperScrubber
    {
        private readonly List<Func<string, string>> scrubbers = new List<Func<string, string>>();

        public void RegisterScrubber(Func<string, string> scrubber)
        {
            scrubbers.Add(scrubber);
        }

        public void RemoveScrubber(Func<string, string> scrubber)
        {
            scrubbers.Remove(scrubber);
        }

        public List<Func<string, string>> GetScrubbers()
        {
            return scrubbers;
        } 

        public string Scrub(string uri)
        {
            return scrubbers.Aggregate(uri, (current, scrubber) => scrubber.Invoke(current));
        }
    }
}
