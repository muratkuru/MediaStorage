using MediaStorage.Common;
using MediaStorage.Common.ViewModels.Tag;
using MediaStorage.Service;
using MediaStorage.Web.Attributes;
using System.Web.Mvc;

namespace MediaStorage.Web.Areas.Administration.Controllers
{
    public class TagController : BaseController
    {
        private ITagService tagService;

        public TagController(ITagService tagService, IMenuItemService menuItemService)
            : base(menuItemService)
        {
            this.tagService = tagService;
        }

        public ActionResult Index()
        {
            return View(tagService.GetAllTags());
        }

        [UrlConstraint]
        public ActionResult AddOrUpdate(int? id)
        {
            if(id.HasValue)
            {
                var tag = tagService.GetTagById(id.Value);
                if (tag == null)
                {
                    TempData["result"] = ServiceResult.NoRecordResult;
                    return RedirectToAction("Index");
                }
                return View(tag);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrUpdate(TagViewModel entity)
        {
            if(ModelState.IsValid)
            {
                if (entity.Id.HasValue)
                    TempData["result"] = tagService.UpdateTag(entity);
                else
                    TempData["result"] = tagService.AddTag(entity);
            }

            return View();
        }

        [UrlConstraint(isNullable: false)]
        public ActionResult Remove(int id)
        {
            TempData["result"] = tagService.RemoveTag(id);

            return RedirectToAction("Index");
        }
    }
}