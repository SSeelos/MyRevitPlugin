using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using MyRevitPlugin;
using MyRevitViewModels;
using Serilog;

namespace MyRevitViews
{
    [Transaction(TransactionMode.Manual)]
    public class MyViewApp : _MyExternalCmd
    {
        public override void TryExecute(ExternalCommandData commandData)
        {
            TaskDialog.Show(this.GetType().FullName, $"Hello {commandData.Application.Application.Username}");

            //var builder = new ContainerBuilder();

            //builder.RegisterType<MainV>().SingleInstance();
            //builder.RegisterType<MainVM>().SingleInstance();

            //IContainer c = builder.Build();
            //c.Resolve<MainV>().Show();

            ILogger logger = new LoggerConfiguration()
                .WriteTo.Debug()
                .CreateLogger();

            var main = new MainV(new MainVM(logger));
            main.Show();
        }
    }
}
