using TowersOfHanoi.Api.Service.Abstracts;

[assembly: WebActivator.PostApplicationStartMethod(typeof(TowersOfHanoi.Api.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace TowersOfHanoi.Api.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using SimpleInjector.Lifestyles;

    public static class SimpleInjectorWebApiInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container)
        {
            container.Register<IMyDbContext, MyDbContext>(Lifestyle.Scoped);
            container.Register(typeof(IRepository<>), typeof(Repository<>));

            container.Register<ITowersOfHanoiService, TowersOfHanoiService>();
            container.Register<ITowersOfHanoiApp, TowersOfHanoiApp>();
        }
    }
}