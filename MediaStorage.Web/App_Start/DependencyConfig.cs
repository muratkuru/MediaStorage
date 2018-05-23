using Autofac;
using Autofac.Integration.Mvc;
using MediaStorage.Data;
using MediaStorage.Service;
using System.Reflection;

namespace MediaStorage.Web.App_Start
{
    public static class DependencyConfig
    {
        public static AutofacDependencyResolver GetDependencyResolver()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MediaContext>().AsSelf().InstancePerRequest();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));

            builder.RegisterType<PageService>().As<IPageService>();
            builder.RegisterType<MaterialTypeService>().As<IMaterialTypeService>();
            builder.RegisterType<AdministratorService>().As<IAdministratorService>();

            IContainer container = builder.Build();

            return new AutofacDependencyResolver(container);
        }
    }
}