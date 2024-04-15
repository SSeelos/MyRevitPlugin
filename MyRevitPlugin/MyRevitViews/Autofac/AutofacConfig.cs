using Autofac;
using MyRevitViewModels;
using Serilog;

namespace MyRevitViews
{
    public static class AutofacConfig
    {
        private static IContainer _container;
        public static IContainer Container
        {
            get
            {
                _container = _container ?? BuildContainer();
                return _container;
            }
        }

        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainV>().SingleInstance();
            builder.RegisterType<MainVM>().SingleInstance();
            builder.Register(c => Log.Logger).As<ILogger>().SingleInstance();
            _container = builder.Build();

            return _container;
        }
    }
}
