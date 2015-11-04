using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TvShowManagerLibrary.Serialization
{
    public static class XmlSerializerHelper
    {
        public static void Serialize(object obj, string filepath)
        {
            using (var writer = new StreamWriter(filepath))
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add(string.Empty, string.Empty);

                var ser = new XmlSerializer(obj.GetType());
                ser.Serialize(writer, obj, ns);
            }
        }

        public static T Deserialize<T>(string filepath)
        {
            if (!File.Exists(filepath))
                return default(T);

            using (var reader = new StreamReader(filepath))
            {
                var serializer = new XmlSerializer(typeof(T));
                var obj = (T)serializer.Deserialize(reader);

                return obj;
            }
        }
    }
}
