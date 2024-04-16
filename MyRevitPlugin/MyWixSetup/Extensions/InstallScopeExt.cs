using System;
using WixSharp;

namespace MyWixSetup
{
    public static class InstallScopeExt
    {
        public static string ToAppDataFolder(this InstallScope installScope)
        {
            switch (installScope)
            {
                case InstallScope.perMachine:
                    //return @"%CommonAppDataFolder%";
                    return Environment.SpecialFolder.CommonApplicationData.GetPath();
                case InstallScope.perUser:
                    //return @"%AppDataFolder%";
                    return Environment.SpecialFolder.ApplicationData.GetPath();
                default:
                    return string.Empty;
            }
        }
        public static string ToRevitAddinsDir(this InstallScope installScope)
            => $@"{installScope.ToAppDataFolder()}\Autodesk\Revit\Addins";
        public static string ToMyRevitDir(this InstallScope installScope)
            => $@"{installScope.ToAppDataFolder()}\My\Revit";
    }

}
