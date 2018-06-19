using MediaStorage.Common;
using MediaStorage.Common.ViewModels.MaterialType;
using MediaStorage.Service;
using MediaStorage.Web.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaStorage.Web.Areas.Administration.Controllers
{
    public class MaterialTypeController : BaseController
    {
        private IMaterialTypeService materialTypeService;

        public MaterialTypeController(IMaterialTypeService materialTypeService, IMenuItemService menuItemService)
            : base(menuItemService)
        {
            this.materialTypeService = materialTypeService;
        }

        public ActionResult Index()
        {
            return View(materialTypeService.GetAllMaterialTypes());
        }

        [UrlConstraint]
        public ActionResult AddOrUpdate(int? id)
        {
            if(id.HasValue)
            {
                var materialType = materialTypeService.GetMaterialTypeById(id.Value);
                if (materialType == null)
                {
                    TempData["result"] = ServiceResult.NoRecordResult;
                    return RedirectToAction("Index");
                }
                return View(materialType);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrUpdate(MaterialTypeViewModel entity)
        {
            if(ModelState.IsValid)
            {
                if (entity.Id.HasValue)
                    TempData["result"] = materialTypeService.UpdateMaterialType(entity);
                else
                    TempData["result"] = materialTypeService.AddMaterialType(entity);
            }

            return View();
        }

        // TODO: Cascade remove
        [UrlConstraint(isNullable: false)]
        public ActionResult Remove(int id, bool cascadeRemove = false)
        {
            TempData["result"] = materialTypeService.RemoveMaterialType(id, cascadeRemove);
            
            return RedirectToAction("Index");
        }
    }
}