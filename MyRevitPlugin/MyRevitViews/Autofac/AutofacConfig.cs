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
                if (_autofacContainer == null)
                    _autofacContainer = BuildContainer();
                return _autofacContainer;
            }
        }

        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainV>().SingleInstance();
            builder.RegisterType<MainVM>().SingleInstance();

            return builder.Build();
        }
    }
}
