using Autodesk.Revit.UI;

namespace MyRevitExtensions
{
    public class MyDockablePaneProvider : IDockablePaneProvider
    {
        protected DockablePaneProviderData _data { get; private set; }
        public void SetupDockablePane(DockablePaneProviderData data)
        {
            _data = data;
            //_data.FrameworkElement = new FrameworkElement();
        }
    }
}
