using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using MyRevitViewModels;
using Nice3point.Revit.Toolkit.External;
using Serilog;

namespace MyRevitViews
{
    [Transaction(TransactionMode.Manual)]
    public class MyViewApp : ExternalCommand
    {
        public override void Execute()
        {
            TaskDialog.Show(this.GetType().FullName, $"Hello {Application.Username}");

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Debug()
                .WriteTo.Sink<RevitSink>()
                .WriteTo.WPFTextblockSink()
                .WriteTo.RevitErrorFileSink($"{Application.CurrentUsersDataFolderPath}\\logs\\myRevitPluginErrorLog.txt")
                .CreateLogger();

            //IContainer container = AutofacConfig.BuildContainer();
            //container.Resolve<MainV>().Show();

            var main = new MainV(new MainVM(Log.Logger));
            main.Show();
        }
    }
}
