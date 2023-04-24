using Autodesk.Revit.UI;

namespace MyRevitPlugin
{
    public static class PulldownButtonExt
    {
        /// <summary>
        /// Adds a new pushbutton and associates it with an <see cref="IExternalCommand"/>
        /// </summary>
        public static PushButton AddPushButton<T>(this PulldownButton pulldown, string txt = null, string toolTip = "")
            where T : IExternalCommand
        {
            txt = txt ?? typeof(T).Name;
            var pushButton = pulldown.AddPushButton(new PushButtonData(typeof(T).Name, txt, typeof(T).Assembly.Location, typeof(T).FullName)
            {
                ToolTip = toolTip,
            });

            return pushButton;
        }
    }
}
