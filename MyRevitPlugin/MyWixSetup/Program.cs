using System;
using WixSharp;

namespace MyWixSetup
{
    class Program
    {
        public static int Main()
        {
#if !DEBUG
            try
            {
                var project = new Project(nameof(MyRevitPlugin))
                {
                    GUID = new Guid("6fe30b47-2577-43ad-9095-1861ba25889b"),
                    Version = new Version("1.0.0.0"),
                    UI = WUI.WixUI_Minimal
                };

                //project.BuildRevitMsi(InstallScope.perUser);
                project.BuildRevitMsi(InstallScope.perMachine);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
            return 0;
#endif
        }
    }
}