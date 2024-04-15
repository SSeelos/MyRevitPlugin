using System.Collections.Generic;
using System.Xml.Serialization;

namespace MyRevitExtensions.AddInFile
{
    public class RevitAddIns
    {
        [XmlElement("AddIn")]
        public List<AddIn> AddIns = new List<AddIn>();
    }
    [XmlInclude(typeof(Application)), XmlInclude(typeof(Command))]
    public abstract class AddIn
    {
        [XmlAttribute]
        public abstract string Type { get; set; }
        public string Assembly { get; set; }
        public string AddInId { get; set; }
        public string FullClassName { get; set; }
        public string VendorId { get; set; }
        public string VendorDescription { get; set; }
    }
    public class Application : AddIn
    {
        [XmlAttribute]
        public override string Type { get; set; } = "Application";
        public string Name { get; set; }
    }
    public class Command : AddIn
    {
        [XmlAttribute]
        public override string Type { get; set; } = "Command";
        public string Text { get; set; }
        [XmlElement("VisibilityMode")]
        public List<string> VisibilityModes { get; set; }
        public string AvailabilityClassName { get; set; }
    }
}
