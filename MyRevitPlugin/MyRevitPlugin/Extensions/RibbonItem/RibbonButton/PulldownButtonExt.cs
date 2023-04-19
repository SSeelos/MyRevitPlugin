using Autodesk.Revit.UI;

namespace MyRevitPlugin
{
    public static class PulldownButtonExt
    {
        public static PushButton AddPushButton<T>(this PulldownButton pulldown, string txt, string toolTip = "")
            where T : IExternalCommand
        {
            var pushButton = pulldown.AddPushButton(new PushButtonData(typeof(T).Name, txt, typeof(T).Assembly.Location, typeof(T).FullName)
            {
                ToolTip = toolTip
            });

            return pushButton;
        }
    }
}
