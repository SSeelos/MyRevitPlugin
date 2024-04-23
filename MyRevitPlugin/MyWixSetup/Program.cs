using MyRevitExtensions.AddInFile;
using MyRevitPlugin;
using System;
using System.IO;
using System.Linq;
using WixSharp;
using WixSharp.Forms;
using WixToolset.Dtf.WindowsInstaller;

namespace MyWixSetup
{
    class Program
    {
        public const string Name
            = nameof(MyRevitPlugin)
#if DEBUG
            + "_Debug"
#endif
            ;
        public static int Main()
        {
            try
            {
                var addinAssembly = System.Reflection.Assembly.Load(nameof(MyRevitPlugin));
                var project = new ManagedProject(Name)
                {
                    GUID = new Guid("6fe30b47-2577-43ad-9095-1861ba25889b"),
                    Version = new Version(addinAssembly.GetVersion()),
                    ControlPanelInfo =
                    {
                        Manufacturer = "MyCompany",
                        ProductIcon = @"Resources\MyIcon.ico"
                    },
                    BackgroundImage = @"Resources\MyBackground.png",
                    BannerImage = @"Resources\MyBanner.png",
                    //LicenceFile = @"Resources\MyLicence.rtf",
                    ManagedUI = new ManagedUI()
                    {
                        InstallDialogs = new ManagedDialogs()
                            .Add(Dialogs.Welcome)
                            //.Add(Dialogs.Licence)
                            //.Add(Dialogs.MaintenanceType)
                            //.Add(Dialogs.Features)
                            //.Add(Dialogs.InstallDir)
                            .Add(Dialogs.Progress)
                            .Add(Dialogs.Exit)
                    },
                };
                project.ManagedUI.ModifyDialogs
                    .Add(Dialogs.MaintenanceType)
                    .Add(Dialogs.Progress)
                    .Add(Dialogs.Exit);

                project.DefaultRefAssemblies.Add(addinAssembly.Location);
                project.DefaultRefAssemblies.Add(typeof(RevitAddIns).Assembly.Location);

                project.AfterInstall += Project_AfterInstall;
                project.BuildRevitMsi(InstallScope.perUser);
                //project.BeforeInstall += Project_BeforeInstall;
                //project.BuildRevitMsi(InstallScope.perMachine);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
            return 0;
        }

        static void Project_AfterInstall(SetupEventArgs e)
        {
            var scope = e.ToScope();
#if DEBUG
            System.Diagnostics.Debugger.Launch();
            e.Session.Message(InstallMessage.Info, new Record($"Scope: {scope}"));
            e.Session.Message(InstallMessage.Info, new Record($"InstallDir: {e.InstallDir}"));
            e.Session.Message(InstallMessage.Info, new Record($"MyPath: {scope.ToMyRevitPath()}"));
            e.Session.Message(InstallMessage.Info, new Record($"RvtPath: {scope.ToRevitAddinsPath()}"));
#endif
            switch (e.Mode)
            {
                case SetupEventArgs.SetupMode.Installing:
                    InstallAddinFile(scope);
                    break;
                //for some reason this is set to modifying when uninstalling
                case SetupEventArgs.SetupMode.Uninstalling:
                case SetupEventArgs.SetupMode.Modifying:
                    if (e.IsUninstalling)
                        UninstallAddinFile(scope);
                    break;
                case SetupEventArgs.SetupMode.Reparing:
                    RepairAddinFile(scope);
                    break;
                default:
                    break;
            }
        }
        public static void RepairAddinFile(InstallScope scope)
        {
            UninstallAddinFile(scope);
            InstallAddinFile(scope);
        }
        public static void InstallAddinFile(InstallScope scope)
        {
            var xmlAddIn = AddInDef.GetAddIns($@"{scope.ToMyRevitPath()}\{Name}")
                .SerializeXml(Resources.XSL);

            var rvtDir = new DirectoryInfo(scope.ToRevitAddinsPath());
            foreach (var dir in rvtDir.GetDirectories())
            {
                dir.NewFileInfo($@"{Name}.addin")
                    .Write(xmlAddIn);
            }
        }
        public static void UninstallAddinFile(InstallScope scope)
        {
            var rvtDir = new DirectoryInfo(scope.ToRevitAddinsPath());
            var files = rvtDir.GetDirectories()
                .SelectMany(d => d.GetFiles($"*{Name}.addin"));
            foreach (var file in files)
            {
                file.Delete();
            }
        }
    }
}