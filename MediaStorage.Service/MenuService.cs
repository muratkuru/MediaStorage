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

        ICollection<MenuItem> GetAllMenuItems();
    }

    public class MenuService : IMenuService
    {
        private IRepository<Menu> menuRepository;
        private IRepository<MenuItem> menuItemRepository;

        public MenuService(IRepository<Menu> menuRepository, IRepository<MenuItem> menuItemRepository)
        {
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
            return new MenuViewModel
            {
                Id = menu.Id,
                Name = menu.Name,
                Description = menu.Description
            };
        }

        public ICollection<MenuItem> GetAllMenuItems()
        {
            return menuItemRepository
                .GetAll(w => w.ParentMenuItemId == null, i => i.SubMenuItems)
                .ToList();
        }
    }
}
