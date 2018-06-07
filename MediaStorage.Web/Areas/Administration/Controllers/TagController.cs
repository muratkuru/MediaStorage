using MediaStorage.Common;
using MediaStorage.Common.ViewModels.Tag;
using MediaStorage.Service;
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

        public ActionResult AddOrUpdate(string id)
        {
            if(!string.IsNullOrEmpty(id))
            {
                if(int.TryParse(id, out int outID))
                {
                    var tag = tagService.GetTagById(outID);
                    if(tag == null)
                    {
                        TempData["result"] = ServiceResult.NoRecordResult;
                        return RedirectToAction("Index");
                    }
                    return View(tag);
                }
                else
                {
                    TempData["result"] = ServiceResult.InvalidIDResult;
                    return RedirectToAction("Index");
                }
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

        public ActionResult Remove(string id)
        {
            if (int.TryParse(id, out int outID))
                TempData["result"] = tagService.RemoveTag(outID);
            else
                TempData["result"] = ServiceResult.InvalidIDResult;

            return RedirectToAction("Index");
        }
    }
}