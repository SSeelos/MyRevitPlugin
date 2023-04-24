using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Macros;

namespace MyRevitPlugin
{
    [Transaction(TransactionMode.ReadOnly)]
    [Regeneration(RegenerationOption.Manual)]
    [AddInId("994c47e3 - ca96 - 4e97 - 83ba - 8eab4e8dc2b0")]
    public class MyThrowingApp : _MyExternalApplication
    {
        protected override void TryOnStartup()
        {
            throw new System.NotImplementedException();
        }
        protected override void TryOnShutdown()
        {
            throw new System.NotImplementedException();
        }
    }
}
