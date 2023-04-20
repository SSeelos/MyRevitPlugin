using Autodesk.Revit.UI;

namespace MyRevitPlugin
{
    public static class RibbonPanelExt
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
    }
}
