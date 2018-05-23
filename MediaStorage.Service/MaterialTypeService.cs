using MediaStorage.Data;
using MediaStorage.Data.Entities;
using MediaStorage.Common.ViewModels;
using System.Collections.Generic;
using System.Linq;
using MediaStorage.Common;
using System;

namespace MediaStorage.Service
{
    public interface IMaterialTypeService
    {
        ICollection<MaterialTypeViewModel> GetAllMaterialTypes();

        ServiceResult CreateMaterialType(MaterialTypeViewModel model);

        ServiceResult DeleteMaterialType(int id);
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

        public ServiceResult CreateMaterialType(MaterialTypeViewModel model)
        {
            int affectedRows = 0;

            if (model != null)
            {
                materialTypeRepository.Add(new MaterialType
                {
                    Name = model.Name
                });
                try
                {
                    affectedRows = uow.Commit();
                }
                catch(Exception ex)
                {
                    return new ServiceResult
                    {
                        IsSuccessful = false,
                        Message = ex.Message
                    };
                }
            }

            return affectedRows == 1
                ? new ServiceResult { IsSuccessful = true, Message = "Ekleme işlemi başarılı." }
                : new ServiceResult { IsSuccessful = false, Message = "Ekleme işlemi başarısız." };
        }

        public ServiceResult DeleteMaterialType(int id)
        {
            int affectedRows = 0;

            materialTypeRepository.Delete(id);

            try
            {
                affectedRows = uow.Commit();
            }
            catch (Exception ex)
            {
                return new ServiceResult
                {
                    IsSuccessful = false,
                    Message = ex.Message
                };
            }

            return affectedRows == 1
                ? new ServiceResult { IsSuccessful = false, Message = "Silme işlemi başarılı." }
                : new ServiceResult { IsSuccessful = false, Message = "Silme işlemi başarısız." };
        }

        public ICollection<MaterialTypeViewModel> GetAllMaterialTypes()
        {
            return materialTypeRepository
                .GetAll()
                .Select(s => new MaterialTypeViewModel
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToList();
        }
    }
}
