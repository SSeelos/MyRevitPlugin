using System.IO;
using System.Linq;
using WixSharp;

namespace MyWixSharpSetup
{
    public static class ProjectExt
    {
        public static void SetAddinManifest(this Project project,
            InstallScope installScope, params WixEntity[] entities)
        {
            project.Scope = installScope;
            project.OutFileName = $"{project.Name}_{installScope}";

            project.Dirs = Directory.GetDirectories(installScope.ToRevitAddinsDirectory())
                .Select(d => new Dir(d, entities))
                .ToArray();
        }
    }
}
