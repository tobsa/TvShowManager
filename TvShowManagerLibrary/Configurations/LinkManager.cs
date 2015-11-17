using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvShowManagerLibrary.Serialization;

namespace TvShowManagerLibrary.Configurations
{
    public class LinkManager
    {
        public static List<Link> DeserializeLinks(string filepath)
        {
            return XmlSerializerHelper.Deserialize<List<Link>>(filepath);
        } 
    }
}
