using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;

namespace MyRevitPlugin
{
    [Transaction(TransactionMode.Manual)]
    public class MyExternalCmd : _MyExternalCommand
    {
        public override void TryExecute(ExternalCommandData commandData)
        {
            var user = commandData.Application.Application.Username;
            TaskDialog.Show(GetType().FullName, $"Hi {user}");
        }
    }
}
