using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Macros;

namespace MyRevitPlugin
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    [AddInId("994c47e3 - ca96 - 4e97 - 83ba - 8eab4e8dc2b0")]
    public class MyExternalApp : _MyExternalApplication
    {
        protected override void TryOnStartup()
        {
            MyRibbonPanelExt.MyRibbonPanel(this.UIControlledApplication);
            MyRibbonPanelExt.DebugPanel(this.UIControlledApplication);
        }
    }
}
