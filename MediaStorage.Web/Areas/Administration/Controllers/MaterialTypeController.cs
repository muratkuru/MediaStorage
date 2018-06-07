using MediaStorage.Common;
using MediaStorage.Common.ViewModels.MaterialType;
using MediaStorage.Service;
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

        public ActionResult AddOrUpdate(string id)
        {
            if(!string.IsNullOrEmpty(id))
            {
                if(int.TryParse(id, out int outID))
                {
                    var materialType = materialTypeService.GetMaterialTypeById(outID);
                    if(materialType == null)
                    {
                        TempData["result"] = ServiceResult.NoRecordResult;
                        return RedirectToAction("Index");
                    }
                    return View(materialType);
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
        public ActionResult Remove(string id, bool cascadeRemove = false)
        {
            if (int.TryParse(id, out int outID))
            {
                TempData["result"] = materialTypeService.RemoveMaterialType(outID, cascadeRemove);
            }
            else
                TempData["result"] = ServiceResult.InvalidIDResult;

            return RedirectToAction("Index");
        }
    }
}