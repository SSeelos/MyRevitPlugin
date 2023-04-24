using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using MyRevitPlugin;

namespace MyRevitViews
{
    [Transaction(TransactionMode.Manual)]
    public class MyViewApp : _MyExternalCmd
    {
        public override void TryExecute(ExternalCommandData commandData)
        {
            TaskDialog.Show(this.GetType().FullName, $"Hello {commandData.Application.Application.Username}");

            new MainV().Show();
        }
    }
}
