using Microsoft.Deployment.WindowsInstaller;

namespace MyWixSharpSetup
{
    public static class CustomActions
    {
        [CustomAction]
        public static ActionResult MyCustomAction(Session session)
        {
            session.Log($"Begin {nameof(MyCustomAction)}");

            return ActionResult.Success;
        }
    }
}
