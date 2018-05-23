using MediaStorage.Data;
using MediaStorage.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MediaStorage.Service
{
    public interface IPageService
    {
        ICollection<Page> GetAllPages();
    }

    public class PageService : IPageService
    {
        private IRepository<Page> pageRepository;

        public PageService(IRepository<Page> pageRepository)
        {
            this.pageRepository = pageRepository;
        }

        public ICollection<Page> GetAllPages()
        {
            return pageRepository
                .GetAll(w => w.ParentPageId == null, i => i.SubPages)
                .ToList();
        }
    }
}
