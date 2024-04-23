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
        public string Assembly { get; set; }
        public string AddInId { get; set; }
        public string FullClassName { get; set; }
        public string VendorId { get; set; }
        public string VendorDescription { get; set; }
    }
    public class Application : AddIn
    {
        public string Name { get; set; }
    }
    public class Command : AddIn
    {
        public string Text { get; set; }
        [XmlElement("VisibilityMode")]
        public List<string> VisibilityModes { get; set; }
        public string AvailabilityClassName { get; set; }
    }
}
