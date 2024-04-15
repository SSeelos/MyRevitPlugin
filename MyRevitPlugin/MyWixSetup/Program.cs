using MyRevitExtensions.AddInFile;
using MyRevitPlugin;
using MyWixSharpSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using WixSharp;

namespace MyWixSetup
{
    internal class Program
    {
        static void Main()
        {

            var project = new Project(nameof(MyRevitPlugin))
            {
                GUID = new Guid("6fe30b47-2577-43ad-9095-1861ba25889b")
            };
            //project.SourceBaseDir = "<input dir path>";
            //project.OutDir = "<output dir path>";

            //todo install files
            var installFile = new Dir("MyDir", new File(@"MyFolder\MyFile.cs"));

            var addinManifest = new RevitAddIns()
            {
                AddIns = new List<AddIn>()
                {
                    MyExternalApp.AddIn
                }
            };
            var xml = addinManifest.SerializeXml();
            System.IO.File.WriteAllText("addinManifest.xml", xml);

            var addinsFile = new File("addinManifest.xml");
            project.SetAddinManifest(InstallScope.perUser, addinsFile);
            project.Dirs.Append(installFile);
            project.BuildMsi();
            project.SetAddinManifest(InstallScope.perMachine, addinsFile);
            project.Dirs.Append(installFile);
            project.BuildMsi();
        }
    }
}