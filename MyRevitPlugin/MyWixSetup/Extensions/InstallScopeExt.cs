using System;
using WixSharp;

namespace MyWixSetup
{
    public static class InstallScopeExt
    {
        /// <summary>
        /// relative path using "%AppDataFolder%"
        /// </summary>
        public static string ToAppDataFolder(this InstallScope installScope)
        {
            switch (installScope)
            {
                case InstallScope.perMachine:
                case InstallScope.perUserOrMachine:
                    return @"%CommonAppDataFolder%";
                case InstallScope.perUser:
                    return @"%AppDataFolder%";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// relative path using "%AppDataFolder%"
        /// </summary>
        public static string ToRevitAddinsFolder(this InstallScope installScope)
            => $@"{installScope.ToAppDataFolder()}\Autodesk\Revit\Addins";
        /// <summary>
        /// relative path using "%AppDataFolder%"
        /// </summary>
        public static string ToMyRevitFolder(this InstallScope installScope)
            => $@"{installScope.ToAppDataFolder()}\My\Revit";

        /// <summary>
        /// full path using <see cref="Environment.SpecialFolder.ApplicationData"/>"/>
        /// </summary>
        public static string ToAppDataPath(this InstallScope installScope)
        {
            switch (installScope)
            {
                case InstallScope.perMachine:
                case InstallScope.perUserOrMachine:
                    return Environment.SpecialFolder.CommonApplicationData.GetPath();
                case InstallScope.perUser:
                    return Environment.SpecialFolder.ApplicationData.GetPath();
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// full path using <see cref="Environment.SpecialFolder.ApplicationData"/>"/>
        /// </summary>
        public static string ToRevitAddinsPath(this InstallScope installScope)
            => $@"{installScope.ToAppDataPath()}\Autodesk\Revit\Addins";
        /// <summary>
        /// full path using <see cref="Environment.SpecialFolder.ApplicationData"/>"/>
        /// </summary>
        public static string ToMyRevitPath(this InstallScope installScope)
            => $@"{installScope.ToAppDataPath()}\My\Revit";
    }

}
