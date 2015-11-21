using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TvShowManagerLibrary.WebScrapers;

namespace TestLibrary
{
    [TestClass]
    public class WebScraperScrubberTests
    {
        [TestMethod]
        public void Scrub_WithNoScrubbers_ReturnAStringUnmodified()
        {
            var scrubber = new WebScraperScrubber();
            
            var scrubbedURI = scrubber.Scrub("This_Is_An_URI");

            Assert.AreEqual("This_Is_An_URI", scrubbedURI);
        }

        [TestMethod]
        public void Scrub_WithASingleScrubber_ReturnAStringCorrectlyScrubbed()
        {
            var scrubber = new WebScraperScrubber();
            scrubber.RegisterScrubber((uri) => uri.Replace("_", "."));

            var scrubbedURI = scrubber.Scrub("This_Is_An_URI");

            Assert.AreEqual("This.Is.An.Uri", scrubbedURI);
        }

        [TestMethod]
        public void Scrub_WithMultipleScrubbers_ReturnAStringCorrectlyScrubbed()
        {
            var scrubber = new WebScraperScrubber();
            scrubber.RegisterScrubber((uri) => uri.Replace("_", "."));
            scrubber.RegisterScrubber((uri) => uri.Replace(".Not.", "."));

            var scrubbedURI = scrubber.Scrub("This_Is_Not_An_URI");

            Assert.AreEqual("This.Is.An.Uri", scrubbedURI);
        }
    }
}
