using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;

namespace MyRevitPlugin
{
    [Transaction(TransactionMode.Manual)]
    public class MyExternalCommand : _MyExternalCommand
    {
        public override void Execute(ExternalCommandData commandData)
        {
            TaskDialog.Show(commandData.View.Name, commandData.View.ViewType.ToString());
        }
    }
}
