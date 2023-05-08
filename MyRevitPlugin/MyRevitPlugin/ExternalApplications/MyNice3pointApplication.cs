using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;
using Nice3point.Revit.Toolkit.External;

namespace MyRevitPlugin
{
    public class MyNice3pointApplication : ExternalApplication
    {
        public override void OnStartup()
        {
            Application app = UiApplication.Application;

            TaskDialog.Show(GetType().FullName, $"Hello {app.Username}");

            MyRibbonPanelExt.MyRibbonPanel(Application);
            MyRibbonPanelExt.DebugPanel(Application);
        }
    }
}
