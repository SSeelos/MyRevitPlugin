using Autodesk.Revit.UI;
using MyRevitExtensions;

namespace MyRevitViewModels
{
    public class MyExternalEvH : _MyExternalEventHandler
    {
        protected override void TryExecute(UIApplication app)
        {
            TaskDialog.Show(GetName(), "Hello" + app.Application.Username);
        }
    }
}
