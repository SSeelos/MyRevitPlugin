using Autodesk.Revit.UI;
using System.Reflection;

namespace MyRevitPlugin
{
    public static class UIControlledApplicationExt
    {
        public static UIApplication GetUIApplication(this UIControlledApplication controlledApplication)
            => (UIApplication)(controlledApplication?.GetType()
            .GetField("m_uiapplication", BindingFlags.Instance | BindingFlags.NonPublic)?
            .GetValue(controlledApplication));
    }
}
