using Autofac;
using MyRevitViewModels;

namespace MyRevitViews
{
    public static class AutofacConfig
    {
        private static IContainer _autofacContainer;
        public static IContainer AutofacContainer
        {
            get
            {
                _autofacContainer = _autofacContainer ?? BuildContainer();
                return _autofacContainer;
            }
        }

        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainV>().SingleInstance();
            builder.RegisterType<MainVM>().SingleInstance();

            _autofacContainer = builder.Build();

            return _autofacContainer;
        }
    }
}
