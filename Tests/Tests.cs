using System;
using System.Security.Cryptography.X509Certificates;
using CoreLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var str =
                "This -|- is random --- sentence seperated by -|- some random delimiters in order to --- test a string extension method";

            var data = str.FindSubstrings("-|-", "---");

            Assert.AreEqual(2, data.Count);
            Assert.AreEqual(" is random ", data[0]);
            Assert.AreEqual(" some random delimiters in order to ", data[1]);
        }
    }
}
