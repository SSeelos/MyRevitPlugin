using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Nice3point.Revit.Toolkit.External;

namespace MyRevitPlugin
{
    [Transaction(TransactionMode.ReadOnly)]
    public class MyNice3pointCommand : ExternalCommand
    {
        public override void Execute()
        {
            var user = this.Application.Username;
            TaskDialog.Show(GetType().FullName, $"Hi {user}");
        }
    }
}
