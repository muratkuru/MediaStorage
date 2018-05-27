using MediaStorage.Common;
using MediaStorage.Common.ViewModels;
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

        ServiceResult RemoveMenu(int id);

        ICollection<MenuItem> GetAllMenuItems();

        ICollection<MenuItemListViewModel> GetMenuItemsByMenuId(int menuId);

        MenuItemAddOrUpdateViewModel GetMenuItemsForAddOrUpdate(int? id);

        ServiceResult AddOrUpdateMenuItem(MenuItemPostViewModel model);

        ServiceResult RemoveMenuItem(int id);
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
            return menuRepository.GetAll(w => !w.IsRemoved).Select(s => new MenuViewModel
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
            if (model.Id.HasValue)
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

        public ServiceResult RemoveMenu(int id)
        {
            menuRepository.Delete(id);

            return uow.Commit() == 1
                ? new ServiceResult(true, "The remove process has successful.")
                : new ServiceResult(false, "The remove process has been unsuccessful.");
        }

        public ICollection<MenuItem> GetAllMenuItems()
        {
            return menuItemRepository
                .GetAll(w => !w.IsRemoved && w.ParentMenuItemId == null, i => i.SubMenuItems)
                .ToList();
        }

        public ICollection<MenuItemListViewModel> GetMenuItemsByMenuId(int menuId)
        {
            return menuItemRepository
                    .GetAll(w => !w.IsRemoved, i => i.Menu, i => i.ParentMenuItem)
                    .Where(w => w.MenuId == menuId)
                    .Select(s => new MenuItemListViewModel
                    {
                        Id = s.Id,
                        Title = s.Title,
                        Action = s.Action,
                        Controller = s.Controller,
                        Area = s.Area,
                        Icon = s.Icon,
                        RowIndex = s.RowIndex,
                        Menu = s.Menu.Name,
                        ParentMenuItem = s.ParentMenuItem.Title
                    }).ToList();
        }

        public MenuItemAddOrUpdateViewModel GetMenuItemsForAddOrUpdate(int? id)
        {
            var menus = menuRepository
                .GetAll(w => !w.IsRemoved)
                .Select(s => new SelectListViewModel
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                }).ToList();
            var parentMenuItems = menuItemRepository
                .GetAll(w => !w.IsRemoved)
                .Select(s => new SelectListViewModel
                {
                    Value = s.Id.ToString(),
                    Text = $"{s.Area}/{s.Controller}/{s.Action}"
                }).ToList();

            if (id.HasValue)
            {
                var menuItem = menuItemRepository.Find(id.Value);
                return menuItem == null ? null : new MenuItemAddOrUpdateViewModel
                {
                    Id = menuItem.Id,
                    Title = menuItem.Title,
                    Action = menuItem.Action,
                    Controller = menuItem.Controller,
                    Area = menuItem.Area,
                    Icon = menuItem.Icon,
                    RowIndex = menuItem.RowIndex,
                    Menus = menus,
                    ParentMenuItems = parentMenuItems
                };
            }

            return new MenuItemAddOrUpdateViewModel
            {
                Menus = menus,
                ParentMenuItems = parentMenuItems
            };
        }

        public ServiceResult AddOrUpdateMenuItem(MenuItemPostViewModel model)
        {
            return null;
        }

        public ServiceResult RemoveMenuItem(int id)
        {
            return null;
        }
    }
}
