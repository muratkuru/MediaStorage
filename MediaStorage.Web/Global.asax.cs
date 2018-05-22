using Autofac;
using Autofac.Integration.Mvc;
using MediaStorage.Data;
using MediaStorage.Service;
using MediaStorage.Web.App_Start;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MediaStorage.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DependencyResolver.SetResolver(GetDependencyResolver());
        }

        private AutofacDependencyResolver GetDependencyResolver()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MediaContext>().AsSelf().InstancePerRequest();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));

            builder.RegisterType<PageService>().As<IPageService>();
            builder.RegisterType<MaterialTypeService>().As<IMaterialTypeService>();

            IContainer container = builder.Build();

            return new AutofacDependencyResolver(container);
        }
    }
}
