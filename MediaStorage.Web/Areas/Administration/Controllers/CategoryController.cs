using MediaStorage.Common;
using MediaStorage.Common.ViewModels.Category;
using MediaStorage.Service;
using MediaStorage.Web.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaStorage.Web.Areas.Administration.Controllers
{
    public class CategoryController : BaseController
    {
        private ICategoryService categoryService;
        private IMaterialTypeService materialTypeService;

        public CategoryController(ICategoryService categoryService, IMaterialTypeService materialTypeService, IMenuItemService menuItemService)
            : base(menuItemService)
        {
            this.categoryService = categoryService;
            this.materialTypeService = materialTypeService;
        }

        public ActionResult Index()
        {
            return View(categoryService.GetAllCategories());
        }

        [UrlConstraint]
        public ActionResult AddOrUpdate(int? id)
        {
            SetAddOrUpdateViewBags(id);

            if (id.HasValue)
            {
                var category = categoryService.GetCategoryById(id.Value);
                if (category == null)
                {
                    TempData["result"] = ServiceResult.NoRecordResult;
                    return RedirectToAction("Index", "Category", new { area = "Administration", id = "" });
                }

                return View(category);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrUpdate(CategoryViewModel entity)
        {
            SetAddOrUpdateViewBags(entity.Id);

            if (ModelState.IsValid)
            {
                if (entity.Id.HasValue)
                    TempData["result"] = categoryService.UpdateCategory(entity);
                else
                    TempData["result"] = categoryService.AddCategory(entity);
            }

            return View();
        }

        // TODO: Cascade remove
        [UrlConstraint(isNullable: false)]
        public ActionResult Remove(int id, bool cascadeRemove = false)
        {
            TempData["result"] = categoryService.RemoveCategory(id);

            return RedirectToAction("Index");
        }

        private void SetAddOrUpdateViewBags(int? id)
        {
            ViewBag.SubCategories = categoryService.GetSubCategoriesAsSelectListItem(id).ToMVCSelectListItem();
            ViewBag.MaterialTypes = materialTypeService.GetMaterialTypesAsSelectListItem(id).ToMVCSelectListItem();
        }
    }
}