using Nuke.Common;
using Serilog;


partial class Build
{
    Target Clean => _ => _
    .Before(Compile)
    .Executes(() =>
    {
        Log.Information("Cleaning...");

    });

    Target Compile => _ => _
        .Executes(() =>
        {
            Log.Information("Compiling...");
        });

    Target Publish => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            Log.Information("Publishing...");
        });

    Target Announce => _ => _
        .TriggeredBy(Publish)
        .Executes(() =>
        {
            Log.Information("Announcing...");
        });
}

