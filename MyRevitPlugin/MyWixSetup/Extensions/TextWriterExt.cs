using System.IO;
using System.Xml;

namespace WixSharp
{
    public static class TextWriterExt
    {
        public static XmlWriter NewXmlWriter(this TextWriter writer, XmlWriterSettings settings = null)
            => XmlWriter.Create(writer, settings);
    }
}
