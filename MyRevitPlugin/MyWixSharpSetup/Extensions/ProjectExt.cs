using WixSharp;

namespace MyWixSharpSetup
{
    public static class ProjectExt
    {

        public static void BuildSingleUserMSI(this Project project,
            string name, WixEntity[] entities)
        {
            project.InstallScope = InstallScope.perUser;
            project.OutFileName = $"{name}_{InstallScope.perUser}";
            project.Dirs = new Dir[]
            {
                new InstallDir(@"%AppDataFolder%\Autodesk\Revit\Addins\2023",entities)
            };
        }
        public static void BuildMSI_Revit(this Project project,
            InstallScope installScope, params WixEntity[] entities)
        {
            project.InstallScope = installScope;
            project.OutFileName = $"{project.Name}_{installScope}";
            project.Dirs = new Dir[]
            {
                new InstallDir(installScope.ToInstallDirectory(),entities)
            };

            project.BuildMsi();
        }
    }
}
