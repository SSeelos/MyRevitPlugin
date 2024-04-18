using MyRevitPlugin;
using System;
using System.Linq;
using WixSharp;
using WixToolset.Dtf.WindowsInstaller;

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
            var dir = $@"{project.Scope.Value.ToMyRevitFolder()}\{project.Name}";
            Console.WriteLine("Install Directory");
            Console.WriteLine(dir);
            project.Dirs = new Dir[] { new InstallDir(dir,
                new Files(@"..\MyRevitPlugin\bin\Release\*.*")
                )};
        }
        //todo: after install | customaction?
        public static void SetAddinManifest(this Project project)
        {
            Console.WriteLine("Generating AddInFile");
            var addinManifest = AddInDef.GetAddIns($"{project.Scope.Value.ToMyRevitFolder()}");
            var xml = addinManifest.SerializeXml();
            System.IO.File.WriteAllText($"{project.Name}.addin", xml);
            var path = System.IO.Path.GetFullPath($"{project.Name}.addin");
            Console.WriteLine($"{path}");

            Console.WriteLine("Revit Directories");
            var dirs = System.IO.Directory.GetDirectories(project.Scope.Value.ToRevitAddinsFolder());
            foreach (var dir in dirs)
            {
                Console.WriteLine(dir);
            }
            project.Dirs = project.Dirs.Concat(dirs
                .Select(dir => new Dir(dir, new File($"{project.Name}.addin")))).ToArray();
        }
        public static void BuildRevitMsi(this ManagedProject project, InstallScope scope)
        {
            project.SetScope(scope);
            project.SetInstallFiles();
            //project.AfterInstall += Project_AfterInstall;
            //project.SetAddinManifest();
            project.BuildMsi();
        }
        public static void Project_AfterInstall(SetupEventArgs e)
        {
#if DEBUG
            System.Diagnostics.Debugger.Launch();
            e.Session.Message(InstallMessage.Info, new Record("Debugger attached"));
            e.Session.Message(InstallMessage.Info, new Record($"Scope={e.ToScope()}"));
#endif
            var scope = e.ToScope();
            Console.WriteLine("Generating AddInFile");
            var addinManifest = AddInDef.GetAddIns($"{scope.ToRevitAddinsPath()}");
            var xml = addinManifest.SerializeXml();
            string addinFileName = $"{nameof(MyRevitPlugin)}.addin";
            System.IO.File.WriteAllText(addinFileName, xml);
            var path = System.IO.Path.GetFullPath(addinFileName);
            Console.WriteLine($"{path}");

            Console.WriteLine("Revit Directories");
            var dirs = System.IO.Directory.GetDirectories(scope.ToRevitAddinsFolder());
            foreach (var dir in dirs)
            {
                Console.WriteLine(dir);
            }
            //place files in Revit Addins directory
            //project.Dirs = project.Dirs.Concat(dirs
            //    .Select(dir => new Dir(dir, new File($"{nameof(MyRevitPlugin)}.addin")))).ToArray();
        }

        [CustomAction]
        public static ActionResult CustomAction(Session session)
        {
            session.Log("Begin CustomAction");

            return ActionResult.Success;
        }

    }
}
