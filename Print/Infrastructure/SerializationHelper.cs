using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Infrastructure
{
    [Serializable]
    public class SerializationHelper
    {
        private SerializationHelper()
        { }

        public static void XmlSerialize(object obj, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(fs, obj);
            }
        }

        public static object XmlDeserializeFromFile(Type type, string fileName)
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (XmlTextReader xtr = new XmlTextReader(fs))
                    {
                        XmlSerializer serializer = new XmlSerializer(type);
                        return serializer.Deserialize(xtr);
                    }
                }
            }
            catch
            {
                File.Delete(fileName);
                return XmlDeserializeFromFile(type, fileName);
            }
        }

        public static string XmlSerialize(object obj, Encoding encoding)
        {
            if (obj == null)
                return null;
            XmlSerializer ser = new XmlSerializer(obj.GetType());
            MemoryStream stream = new MemoryStream();
            StreamWriter sWriter = new StreamWriter(stream, encoding);
            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add(string.Empty, string.Empty);
            ser.Serialize(sWriter, obj, xsn);
            string str = encoding.GetString(stream.ToArray());
            stream.Close();
            return str;
        }

        public static string XmlSerialize(object obj)
        {
            if (obj == null)
                return null;
            XmlSerializer ser = new XmlSerializer(obj.GetType());
            StringWriter sWriter = new StringWriter();
            ser.Serialize(sWriter, obj);
            return sWriter.ToString();
        }

        public static object XmlDeserialize(Type type, string xmlStr)
        {
            if (xmlStr == null || xmlStr.Trim() == "")
                return null;
            using (XmlTextReader xtr = new XmlTextReader(xmlStr))
            {
                XmlSerializer serializer = new XmlSerializer(type);
                return serializer.Deserialize(xtr);
            }
        }
    }
}
