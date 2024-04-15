using WixSharp;

namespace MyWixSharpSetup
{
    public static class ProjectExt
    {
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
