using Autodesk.Revit.UI;

namespace MyRevitPlugin
{
    public class MyExternalApp : _MyExternalApplication
    {
        protected override void TryOnStartup()
        {
            var app = this.UIControlledApplication.GetUIApplication().Application;
            TaskDialog.Show(GetType().FullName, $"Hello {app.Username}");


            RibbonPanelExt.DebugPanel(this.UIControlledApplication);
        }
    }
}
