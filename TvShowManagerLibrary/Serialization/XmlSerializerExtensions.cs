using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TvShowManagerLibrary.Serialization
{
    public static class XmlSerializerExtensions
    {
        public static void Serialize(this XmlSerializer serializer, object obj, string filename)
        {
            using (var writer = new StreamWriter(filename))
            {
                var ser = new XmlSerializer(obj.GetType());
                ser.Serialize(writer, obj);
            }
        }
    }
}
