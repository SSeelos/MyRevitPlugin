using System.IO;
using System.Xml;

namespace WixSharp
{
    public static class TexRreaderExt
    {
        public static XmlReader NewXmlReader(this TextReader reader)
            => XmlReader.Create(reader);
    }
}
