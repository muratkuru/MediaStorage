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

        MenuViewModel GetMenuById(int id);

        ServiceResult AddOrUpdateMenu(MenuViewModel model);

        ICollection<MenuItem> GetAllMenuItems();
    }

    public class MenuService : IMenuService
    {
        private IUnitOfWork uow;
        private IRepository<Menu> menuRepository;
        private IRepository<MenuItem> menuItemRepository;

        public MenuService(IUnitOfWork uow, IRepository<Menu> menuRepository, IRepository<MenuItem> menuItemRepository)
        {
            this.uow = uow;
            this.menuRepository = menuRepository;
            this.menuItemRepository = menuItemRepository;
        }

        public ICollection<MenuViewModel> GetAllMenus()
        {
            return menuRepository.GetAll().Select(s => new MenuViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description
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

        public ServiceResult AddOrUpdateMenu(MenuViewModel model)
        {
            if(model.Id.HasValue)
            {
                menuRepository.Update(new Menu
                {
                    Id = model.Id.Value,
                    Name = model.Name,
                    Description = model.Description
                });
            }
            else
            {
                menuRepository.Add(new Menu
                {
                    Name = model.Name,
                    Description = model.Description
                });
            }

            string message = model.Id.HasValue
                ? "The update process has "
                : "The add process has ";



            return uow.Commit() == 1
                ? new ServiceResult(true, message + "successful.")
                : new ServiceResult(false, message + "been unsuccessful.");
        }

        public ICollection<MenuItem> GetAllMenuItems()
        {
            return menuItemRepository
                .GetAll(w => w.ParentMenuItemId == null, i => i.SubMenuItems)
                .ToList();
        }
    }
}
