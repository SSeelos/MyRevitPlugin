using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;

namespace MyRevitPlugin
{
    [Transaction(TransactionMode.ReadOnly)]
    public class MyThrowingCommand : _MyExternalCmd
    {
        public override void TryExecute(ExternalCommandData commandData)
        {
            throw new System.NotImplementedException();
        }
    }
}
