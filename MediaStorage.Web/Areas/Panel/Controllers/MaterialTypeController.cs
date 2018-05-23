using MediaStorage.Common;
using MediaStorage.Common.ViewModels;
using MediaStorage.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaStorage.Web.Areas.Panel.Controllers
{
    public class MaterialTypeController : BaseController
    {
        private IMaterialTypeService materialTypeService;

        public MaterialTypeController(IPageService pageService, IMaterialTypeService materialTypeService)
            : base(pageService)
        {
            this.materialTypeService = materialTypeService;
        }

        public ActionResult Index()
        {
            var materialTypes = materialTypeService.GetAllMaterialTypes();

            return View(materialTypes);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MaterialTypeViewModel model)
        {
            ServiceResult result = null;

            if (ModelState.IsValid)
            {
                result = materialTypeService.CreateMaterialType(model);
            }
            else
            {
                result = new ServiceResult
                {
                    IsSuccessful = false,
                    Message = "Ekleme işlemi başarısız."
                };
            }

            if (!result.IsSuccessful)
                ModelState.AddModelError("error", result.Message);

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            ServiceResult result = materialTypeService.DeleteMaterialType(id);

            return RedirectToAction("Index");
        }
    }
}