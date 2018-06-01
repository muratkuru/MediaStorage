using MediaStorage.Common;
using MediaStorage.Common.ViewModels.Menu;
using MediaStorage.Data;
using MediaStorage.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MediaStorage.Service
{
    public interface IMenuService
    {
        ICollection<MenuViewModel> GetAllMenus();

        ICollection<CustomSelectListItem> GetAllMenusBySelectListItem(int? id);

        MenuViewModel GetMenuById(int id);

        ServiceResult AddMenu(MenuViewModel entity);

        ServiceResult UpdateMenu(MenuViewModel entity);

        ServiceResult RemoveMenu(int id);
    }

    public class MenuService : IMenuService
    {
        private IUnitOfWork uow;
        private IRepository<Menu> menuRepository;

        public MenuService(IUnitOfWork uow, IRepository<Menu> menuRepository)
        {
            this.uow = uow;
            this.menuRepository = menuRepository;
        }

        public ICollection<MenuViewModel> GetAllMenus()
        {
            return menuRepository
                .GetAll()
                .Select(s => new MenuViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description
                }).ToList();
        }

        public ICollection<CustomSelectListItem> GetAllMenusBySelectListItem(int? id)
        {
            return menuRepository
                .GetAll()
                .Select(s => new CustomSelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name,
                    Selected = id.HasValue ? s.MenuItems.Any(a => a.Id == id.Value) : false
                }).ToList();
        }

        public MenuViewModel GetMenuById(int id)
        {
            var menu = menuRepository.Find(id);
            return menu == null ? null : new MenuViewModel
            {
                Id = menu.Id,
                Name = menu.Name,
                Description = menu.Description
            };
        }

        public ServiceResult AddMenu(MenuViewModel entity)
        {
            menuRepository.Add(new Menu
            {
                Name = entity.Name,
                Description = entity.Description
            });

            return uow.Commit() == 1
                ? new ServiceResult(true, "The add process has successful.")
                : new ServiceResult(false, "The add process has been unsuccessful.");
        }

        public ServiceResult UpdateMenu(MenuViewModel entity)
        {
            menuRepository.Update(new Menu
            {
                Id = entity.Id.Value,
                Name = entity.Name,
                Description = entity.Description
            });

            return uow.Commit() == 1
                ? new ServiceResult(true, "The update process has successful.")
                : new ServiceResult(false, "The update process has been unsuccessful.");
        }

        public ServiceResult RemoveMenu(int id)
        {
            menuRepository.Delete(id);

            return uow.Commit() == 1
                ? new ServiceResult(true, "The remove process has successful.")
                : new ServiceResult(false, "The remove process has been unsuccessful.");
        }
    }
}
