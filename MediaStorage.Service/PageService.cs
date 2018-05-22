using MediaStorage.Data;
using MediaStorage.Data.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MediaStorage.Service
{
    public interface IPageService
    {
        ICollection<Page> GetAllPages();
    }

    public class PageService : IPageService
    {
        private IUnitOfWork uow;
        private IRepository<Page> pageRepository;

        public PageService(IUnitOfWork uow, IRepository<Page> pageRepository)
        {
            this.uow = uow;
            this.pageRepository = pageRepository;
        }

        public ICollection<Page> GetAllPages()
        {
            return pageRepository
                .GetAll(w => w.ParentPageId == null)
                .Include(i => i.SubPages)
                .ToList();
        }
    }
}
