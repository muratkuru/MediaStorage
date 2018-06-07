using MediaStorage.Data;
using MediaStorage.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using MediaStorage.Common;
using MediaStorage.Common.ViewModels.MaterialType;

namespace MediaStorage.Service
{
    public interface IMaterialTypeService
    {
        ICollection<MaterialTypeViewModel> GetAllMaterialTypes();

        MaterialTypeViewModel GetMaterialTypeById(int id);

        ServiceResult AddMaterialType(MaterialTypeViewModel entity);

        ServiceResult UpdateMaterialType(MaterialTypeViewModel entity);

        ServiceResult RemoveMaterialType(int id, bool cascadeRemove = false);
    }

    public class MaterialTypeService : IMaterialTypeService
    {
        private IUnitOfWork uow;
        private IRepository<MaterialType> materialTypeRepository;

        public MaterialTypeService(IUnitOfWork uow, IRepository<MaterialType> materialTypeRepository)
        {
            this.uow = uow;
            this.materialTypeRepository = materialTypeRepository;
        }

        public ICollection<MaterialTypeViewModel> GetAllMaterialTypes()
        {
            return materialTypeRepository
                .GetAll()
                .Select(s => new MaterialTypeViewModel
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToList();
        }

        public MaterialTypeViewModel GetMaterialTypeById(int id)
        {
            var materialType = materialTypeRepository.Find(id);

            return materialType == null ? null : new MaterialTypeViewModel
            {
                Id = materialType.Id,
                Name = materialType.Name
            };
        }

        public ServiceResult AddMaterialType(MaterialTypeViewModel entity)
        {
            materialTypeRepository.Add(new MaterialType
            {
                Name = entity.Name
            });

            return ServiceResult.GetAddResult(uow.Commit() == 1);
        }

        public ServiceResult UpdateMaterialType(MaterialTypeViewModel entity)
        {
            materialTypeRepository.Update(new MaterialType
            {
                Id = entity.Id.Value,
                Name = entity.Name
            });

            return ServiceResult.GetUpdateResult(uow.Commit() == 1);
        }

        public ServiceResult RemoveMaterialType(int id, bool cascadeRemove = false)
        {
            if(cascadeRemove)
            {
                // TODO: Cascade remove
                //var materialType = materialTypeRepository.GetAll(w => w.Id == id, i => i.Materials, i => i.Categories, i => i.MaterialTypeProperties).ToList();
                //if (materialType.Count > 0)
                //    materialTypeRepository.DeleteRange(materialType);
            }

            materialTypeRepository.Delete(id);

            return ServiceResult.GetRemoveResult(uow.Commit() > 0);
        }
    }
}
