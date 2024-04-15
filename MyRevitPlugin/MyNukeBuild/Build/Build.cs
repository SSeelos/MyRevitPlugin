using Nuke.Common;
using Nuke.Common.ProjectModel;

partial class Build : NukeBuild
{
    [Solution(GenerateProjects = true)]
    readonly Solution Solution;
    public static int Main() => Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;



}
