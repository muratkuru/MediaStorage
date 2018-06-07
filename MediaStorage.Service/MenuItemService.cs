using MediaStorage.Common;
using MediaStorage.Common.ViewModels.Menu;
using MediaStorage.Data;
using MediaStorage.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MediaStorage.Service
{
    public interface IMenuItemService
    {
        ICollection<MenuItemListViewModel> GetAllMenuItems();

        ICollection<CustomSelectListItem> GetMenuItemsBySelectListItem(int? id);

        ICollection<MenuItem> GetAdministrationMenuItems();

        ICollection<MenuItemListViewModel> GetMenuItemsByFilter(int? menuId);

        bool HasMenuItemsByMenuId(int menuId);

        MenuItemPostViewModel GetMenuItemById(int id);

        ServiceResult AddMenuItem(MenuItemPostViewModel entity);

        ServiceResult UpdateMenuItem(MenuItemPostViewModel entity);

        ServiceResult RemoveMenuItem(int id);
    }

    public class MenuItemService : IMenuItemService
    {
        private IUnitOfWork uow;
        private IRepository<MenuItem> menuItemRepository;
        private IUserRoleService userRoleService;

        public MenuItemService(IUnitOfWork uow, IRepository<MenuItem> menuItemRepository, IUserRoleService userRoleService)
        {
            this.uow = uow;
            this.menuItemRepository = menuItemRepository;
            this.userRoleService = userRoleService;
        }

        public ICollection<MenuItemListViewModel> GetAllMenuItems()
        {
            return menuItemRepository.GetAll()
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

        public ICollection<CustomSelectListItem> GetMenuItemsBySelectListItem(int? id)
        {
            int? parentMenuItemId = id.HasValue ? menuItemRepository.Find(id.Value)?.ParentMenuItemId : null;

            return menuItemRepository.GetAll()
                .Select(s => new CustomSelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = (s.ParentMenuItem != null
                            ? s.ParentMenuItem.Title + " > "
                            : string.Empty) + s.Title,
                    Selected = id.HasValue ? s.Id == parentMenuItemId : false
                }).ToList();
        }

        // TODO: Refactoring
        public ICollection<MenuItem> GetAdministrationMenuItems()
        {
            return menuItemRepository
                .GetAll(w => w.ParentMenuItem == null && w.Menu.Name == "Administration", i => i.SubMenuItems)
                .OrderBy(o => o.RowIndex)
                .ToList();
        }

        public ICollection<MenuItemListViewModel> GetMenuItemsByFilter(int? menuId)
        {
            var menuItems = menuItemRepository
                    .GetAll(i => i.Menu, i => i.ParentMenuItem);

            if (menuId.HasValue)
                menuItems = menuItems.Where(w => w.MenuId == menuId);

            return menuItems.Select(s => new MenuItemListViewModel
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

        public bool HasMenuItemsByMenuId(int menuId)
        {
            return menuItemRepository.Any(w => w.MenuId == menuId);
        }

        public MenuItemPostViewModel GetMenuItemById(int id)
        {
            var menuItem = menuItemRepository.Find(id);
            return menuItem == null ? null : new MenuItemPostViewModel
            {
                Id = menuItem.Id,
                Title = menuItem.Title,
                Action = menuItem.Action,
                Controller = menuItem.Controller,
                Area = menuItem.Area,
                Icon = menuItem.Icon,
                RowIndex = menuItem.RowIndex
            };
        }

        public ServiceResult AddMenuItem(MenuItemPostViewModel entity)
        {
            var userRoles = userRoleService.GetUserRolesByIds(entity.UserRoleIds);

            menuItemRepository.Add(new MenuItem
            {
                Title = entity.Title,
                Action = entity.Action,
                Controller = entity.Controller,
                Area = entity.Area,
                Icon = entity.Icon,
                RowIndex = entity.RowIndex,
                ParentMenuItemId = entity.ParentMenuItemId,
                MenuId = entity.MenuId,
                UserRoles = userRoles
            });

            return ServiceResult.GetAddResult(uow.Commit() > 0);
        }

        public ServiceResult UpdateMenuItem(MenuItemPostViewModel entity)
        {
            var userRoles = userRoleService.GetUserRolesByIds(entity.UserRoleIds);

            var menuItem = menuItemRepository.Get(w => w.Id == entity.Id.Value, i => i.UserRoles);

            menuItem.Title = entity.Title;
            menuItem.Action = entity.Action;
            menuItem.Controller = entity.Controller;
            menuItem.Area = entity.Area;
            menuItem.Icon = entity.Icon;
            menuItem.RowIndex = entity.RowIndex;
            menuItem.ParentMenuItemId = entity.ParentMenuItemId;
            menuItem.MenuId = entity.MenuId;
            menuItem.UserRoles = userRoles;

            menuItemRepository.Update(menuItem);

            return ServiceResult.GetUpdateResult(uow.Commit() > 0);
        }

        public ServiceResult RemoveMenuItem(int id)
        {
            var menuItem = menuItemRepository.Get(w => w.Id == id, i => i.UserRoles);
            if (menuItem != null)
                menuItemRepository.Delete(menuItem);

            return ServiceResult.GetRemoveResult(uow.Commit() > 0);
        }
    }
}
