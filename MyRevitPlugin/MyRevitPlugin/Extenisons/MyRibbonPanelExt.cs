using Autodesk.Revit.UI;
using MyRevitViews;

namespace MyRevitPlugin
{
    public class MyRibbonPanelExt
    {

        public static RibbonPanel DebugPanel(UIControlledApplication application)
        {
#if DEBUG
            var panel = application.CreateRibbonPanel(Tab.AddIns, nameof(MyRevitPlugin));
            var button = panel.AddItem(new PulldownButtonData("myPulldownButton", "My" + nameof(PulldownButtonData))) as PulldownButton;
            button.AddPushButton<MyExternalCommand>();
            button.AddPushButton<MyThrowingCommand>();
            button.AddPushButton<MyNice3pointCommand>();
            button.AddPushButton<LoadFromDll>();
            return panel;
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
