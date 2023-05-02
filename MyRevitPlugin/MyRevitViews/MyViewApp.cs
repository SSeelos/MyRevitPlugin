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

            //var builder = new ContainerBuilder();

            //builder.RegisterType<MainV>().SingleInstance();
            //builder.RegisterType<MainVM>().SingleInstance();

            //IContainer c = builder.Build();
            //c.Resolve<MainV>().Show();

            ILogger logger = new LoggerConfiguration()
                .WriteTo.Debug()
                .WriteTo.Sink<RevitSink>()
                .CreateLogger();

            var main = new MainV(new MainVM(logger));
            main.Show();
        }
    }
}
