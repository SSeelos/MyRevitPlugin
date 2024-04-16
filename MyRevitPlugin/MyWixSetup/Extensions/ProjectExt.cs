using MyRevitPlugin;
using System;
using System.Linq;
using WixSharp;

namespace MyWixSetup
{
    public static class ProjectExt
    {
        public static void SetScope(this Project project, InstallScope scope)
        {
            project.Scope = scope;
            project.OutFileName = $"{project.Name}_{scope}";
        }
        public static void SetInstallFiles(this Project project)
        {
            var dir = project.Scope.Value.ToMyRevitDir();
            Console.WriteLine("Install Directory");
            Console.WriteLine(dir);
            project.Dirs = new Dir[] { new InstallDir(dir,
                new Files(@"..\MyRevitPlugin\bin\Release\*.*")
                )};
        }
        public static void SetAddinManifest(this Project project)
        {
            Console.WriteLine("Generating AddInFile");
            var addinManifest = AddInDef.GetAddIns($"{project.Scope.Value.ToMyRevitDir()}");
            var xml = addinManifest.SerializeXml();
            System.IO.File.WriteAllText($"{project.Name}.addin", xml);

            var dirs = System.IO.Directory.GetDirectories(project.Scope.Value.ToRevitAddinsDir());
            Console.WriteLine("Revit Directories");
            foreach (var dir in dirs)
            {
                Console.WriteLine(dir);
            }
            project.Dirs = project.Dirs.Concat(dirs
                .Select(dir => new Dir(dir, new File($"{project.Name}.addin")))).ToArray();
        }
        public static void BuildRevitMsi(this Project project, InstallScope scope)
        {
            project.SetScope(scope);
            project.SetInstallFiles();
            project.SetAddinManifest();
            project.BuildMsi();
        }
    }
}
