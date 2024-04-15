using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Macros;
using MyRevitExtensions.AddInFile;

namespace MyRevitPlugin
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    [AddInId(AddInId)]
    public class MyExternalApp : _MyExternalApplication
    {
        public const string AddInId = "994c47e3-ca96-4e97-83ba-8eab4e8dc2b0";
        protected override void TryOnStartup()
        {
            var app = this.UIControlledApplication.GetUIApplication().Application;
            TaskDialog.Show(GetType().FullName, $"Hello {app.Username}");

            MyRibbonPanelExt.MyRibbonPanel(this.UIControlledApplication);
            MyRibbonPanelExt.DebugPanel(this.UIControlledApplication);

        }
        public static AddIn AddIn => new Application()
        {
            Name = nameof(MyExternalApp),
            //Assembly = $@"{nameof(MyExternalApp)}\{nameof(MyExternalApp)}.dll",
            Assembly = typeof(MyExternalApp).Assembly.Location,
            AddInId = AddInId,
            FullClassName = typeof(MyExternalApp).FullName,
            VendorId = "MyVendorId",
            VendorDescription = "MyVendorDescription"
        };
    }
}
