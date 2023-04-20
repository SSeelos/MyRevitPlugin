using Autodesk.Revit.Attributes;

namespace MyRevitPlugin
{
    [Transaction(TransactionMode.ReadOnly)]
    public class MyThrowingApp : _MyExternalApplication
    {
        protected override void TryOnStartup()
        {
            throw new System.NotImplementedException();
        }
        protected override void TryOnShutdown()
        {
            throw new System.NotImplementedException();
        }
    }
}
