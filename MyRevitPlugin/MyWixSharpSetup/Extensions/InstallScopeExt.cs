using WixSharp;

namespace MyWixSharpSetup
{
    public static class InstallScopeExt
    {
        public static string ToInstallDirectory(this InstallScope installScope)
        {
            switch (installScope)
            {
                case InstallScope.perMachine:
                    return @"%CommonAppDataFolder%\Autodesk\Revit\Addins\2023";
                case InstallScope.perUser:
                    return @"%AppDataFolder%\Autodesk\Revit\Addins\2023";
                default:
                    return string.Empty;
            }
        }
    }

}
