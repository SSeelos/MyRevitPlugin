using Autodesk.Revit.UI;

namespace MyRevitPlugin
{
    public static class RibbonPanelExt
    {
        public static RibbonItem AddButton<T>(this RibbonPanel panel, string btnTxt = null)
            where T : IExternalCommand
        {
            btnTxt = btnTxt ?? typeof(T).Name;
            var pushButton = new PushButtonData(typeof(T).Name, btnTxt, typeof(T).Assembly.Location, typeof(T).FullName);

            return panel.AddItem(pushButton);
        }
    }
}
