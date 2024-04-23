using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace WixSharp
{
    public static class XmlReaderExt
    {
        public static string GetXSLTransformedXML(this XmlReader reader, string xslt, Action<XmlWriterSettings> setSettings = null)
        {
            var xslct = new XslCompiledTransform();
            xslct.Load(xslt.NewStringReader().NewXmlReader(), new XsltSettings(true, true), new XmlUrlResolver());

            XmlWriterSettings settings = xslct.OutputSettings.Clone();
            setSettings?.Invoke(settings);

            using (var writer = new StringWriter())
            using (var xmlWriter = writer.NewXmlWriter(settings))
            {
                xslct.Transform(reader, new XsltArgumentList(), xmlWriter, new XmlUrlResolver());
                return writer.ToString();
            }
        }
    }
}
