using Autodesk.Revit.UI;
using MyRevitViews;

namespace MyRevitPlugin
{
    public class MyRibbonPanelExt
    {
        public static RibbonPanel DebugPanel(UIControlledApplication application)
        {
            RibbonPanel panel = application.CreateRibbonPanel(Tab.AddIns, nameof(MyRevitPlugin) + "(Debug)");
            PulldownButton button = panel.AddItem(new PulldownButtonData("myPulldownButton", "My" + nameof(PulldownButtonData))) as PulldownButton;
            button.AddPushButton<MyExternalCmd>();
            button.AddPushButton<MyThrowingCommand>();
            button.AddPushButton<MyNice3pointCommand>();
            button.AddPushButton<LoadFromDll>();
            return panel;

            //Debug tab for developers (experimental)
            //var ribbonControl = (RevitRibbonControl)ComponentManager.Ribbon;
            //if (ribbonControl.FindTab("Debug") is null)
            //    ribbonControl.Tabs.Add(ribbonControl.DebugTab);
        }
        public static RibbonPanel MyRibbonPanel(UIControlledApplication application)
        {
            application.CreateRibbonTab(nameof(MyRevitPlugin));

            RibbonPanel panel = application.CreateRibbonPanel(nameof(MyRevitPlugin), "My" + nameof(RibbonPanel));
            panel.AddButton<MyViewApp>();

            return panel;
        }
    }
}
