using WixSharp;

namespace MyWixSharpSetup
{
    public static class InstallScopeExt
    {
        public static string ToAppDataFolder(this InstallScope installScope)
        {
            switch (installScope)
            {
                case InstallScope.perMachine:
                    return @"%CommonAppDataFolder%";
                case InstallScope.perUser:
                    return @"%AppDataFolder%";
                default:
                    return string.Empty;
            }
        }
        public static string ToRevitAddinsDirectory(this InstallScope installScope)
            => $@"{installScope.ToAppDataFolder()}\Autodesk\Revit\Addins";
    }

}
