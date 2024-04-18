using System;

namespace WixSharp
{
    public static class SetupEventArgsExt
    {
        public static InstallScope ToScope(this SetupEventArgs args)
            => args.InstallDir.Contains(Environment.SpecialFolder.ApplicationData.GetPath())
                ? InstallScope.perUser
                : InstallScope.perMachine;
    }
}
