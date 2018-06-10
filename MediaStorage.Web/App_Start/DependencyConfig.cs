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

            builder.RegisterType<MenuService>().As<IMenuService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<UserRoleService>().As<IUserRoleService>();
            builder.RegisterType<MenuItemService>().As<IMenuItemService>();
            builder.RegisterType<LibraryService>().As<ILibraryService>();
            builder.RegisterType<DepartmentService>().As<IDepartmentService>();
            builder.RegisterType<TagService>().As<ITagService>();
            builder.RegisterType<MaterialTypeService>().As<IMaterialTypeService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();

            IContainer container = builder.Build();

            return new AutofacDependencyResolver(container);
        }
    }
}