using WixToolset.Dtf.WindowsInstaller;

namespace WixSharp
{
    public static class CustomActions
    {
        [CustomAction]
        public static ActionResult CustomAction(Session session)
        {
#if DEBUG
            System.Diagnostics.Debugger.Launch();
            session.Message(InstallMessage.Info, new Record("Debugger attached"));
            session.Message(InstallMessage.Info, new Record($"{session.Database}"));
#endif
            session.Log("Begin CustomAction");
            return ActionResult.Success;
        }

    }
}
