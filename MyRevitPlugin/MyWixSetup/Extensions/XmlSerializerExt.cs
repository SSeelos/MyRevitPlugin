using System.IO;
using System.Xml.Serialization;

namespace WixSharp
{
    public static class XmlSerializerExt
    {
        public static string SerializeXml<T>(this T obj)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, obj);
                return stringWriter.ToString();
            }
        }
    }
}
