using MediaStorage.Data;
using MediaStorage.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MediaStorage.Service
{
    public interface IMenuService
    {
        ICollection<MenuItem> GetAllMenuItems();
    }

    public class MenuService : IMenuService
    {
        private IRepository<MenuItem> menuRepository;

        public MenuService(IRepository<MenuItem> menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        public ICollection<MenuItem> GetAllMenuItems()
        {
            return menuRepository
                .GetAll(w => w.ParentMenuItemId == null, i => i.SubMenuItems)
                .ToList();
        }
    }
}
