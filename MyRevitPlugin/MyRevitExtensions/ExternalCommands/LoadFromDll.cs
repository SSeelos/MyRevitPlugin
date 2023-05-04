using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using System.IO;

namespace MyRevitPlugin
{
    [Transaction(TransactionMode.ReadOnly)]
    public class LoadFromDll : _MyExternalCommand
    {
        public override void TryExecute(ExternalCommandData commandData)
        {
            var files = Directory.EnumerateFiles(this.GetDirectory(), "*.dll");
            foreach (var file in files)
            {
                //todo
            }
        }
    }
}
