using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TvShowManagerLibrary.Configurations
{
    public class Link
    {
        [XmlAttribute]
        public string Name { get; set; }
        public string PreValue { get; set; }
        public string PostValue { get; set; }
    }
}
