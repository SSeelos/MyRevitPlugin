using System;
using WixSharp;

namespace MyWixSharpSetup
{
    internal class Program
    {
        static void Main()
        {
            var project = new Project(nameof(MyRevitPlugin));

            project.GUID = new Guid("6fe30b47-2577-43ad-9095-1861ba25889b");
            //project.SourceBaseDir = "<input dir path>";
            //project.OutDir = "<output dir path>";

            //todo install files
            var installFile = new Dir("MyDir", new File(@"MyFolder\MyFile.cs"));
            project.BuildMSI_Revit(InstallScope.perUser, installFile);
            project.BuildMSI_Revit(InstallScope.perMachine, installFile);
        }
    }
}