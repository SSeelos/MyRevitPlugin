using Autodesk.Revit.UI;
using MyRevitViews;
namespace MyRevitPlugin
{
    public class MyRibbonPanelExt
    {

        public static RibbonPanel DebugPanel(UIControlledApplication application)
        {
#if DEBUG
            RibbonPanel panel = application.CreateRibbonPanel(Tab.AddIns, nameof(MyRevitPlugin) + "(Debug)");
            PulldownButton button = panel.AddItem(new PulldownButtonData("myPulldownButton", "My" + nameof(PulldownButtonData))) as PulldownButton;
            button.AddPushButton<MyExternalCommand>();
            button.AddPushButton<MyThrowingCommand>();
            button.AddPushButton<MyNice3pointCommand>();
            button.AddPushButton<LoadFromDll>();
            return panel;

            //Debug tab for developers (experimental)
            //var ribbonControl = (RevitRibbonControl)ComponentManager.Ribbon;
            //if (ribbonControl.FindTab("Debug") is null)
            //    ribbonControl.Tabs.Add(ribbonControl.DebugTab);

#endif
        }
        public static RibbonPanel MyRibbonPanel(UIControlledApplication application)
        {
            application.CreateRibbonTab(nameof(MyRevitPlugin));

            var panel = application.CreateRibbonPanel(nameof(MyRevitPlugin), nameof(MyRevitPlugin) + "Panel");
            panel.AddButton<MyViewApp>("myButton");

            return panel;
        }
    }
}
