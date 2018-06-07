using MediaStorage.Common;
using MediaStorage.Common.ViewModels.Department;
using MediaStorage.Data;
using MediaStorage.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MediaStorage.Service
{
    public interface IDepartmentService
    {
        ICollection<DepartmentListViewModel> GetAllDepartments();

        ICollection<DepartmentListViewModel> GetDepartmentsByLibraryId(int libraryId);

        DepartmentViewModel GetDepartmentById(int id);

        bool HasDepartmentsByLibraryId(int libraryId);

        ServiceResult AddDepartment(DepartmentViewModel entity);

        ServiceResult UpdateDepartment(DepartmentViewModel entity);

        ServiceResult RemoveDepartment(int id, bool cascadeRemove = false);
    }

    public class DepartmentService : IDepartmentService
    {
        private IUnitOfWork uow;
        private IRepository<Department> departmentRepository;

        public DepartmentService(IUnitOfWork uow, IRepository<Department> departmentRepository)
        {
            this.uow = uow;
            this.departmentRepository = departmentRepository;
        }

        public ICollection<DepartmentListViewModel> GetAllDepartments()
        {
            return departmentRepository
                .GetAll(i => i.Library)
                .Select(s => new DepartmentListViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    LibraryName = s.Library.Name
                }).ToList();
        }
        public ICollection<DepartmentListViewModel> GetDepartmentsByLibraryId(int libraryId)
        {
            return departmentRepository
                .GetAll(w => w.LibraryId == libraryId, i => i.Library)
                .Select(s => new DepartmentListViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    LibraryName = s.Library.Name
                }).ToList();
        }

        public DepartmentViewModel GetDepartmentById(int id)
        {
            var department = departmentRepository.Find(id);

            return department == null ? null : new DepartmentViewModel
            {
                Id = department.Id,
                Name = department.Name,
                LibraryId = department.LibraryId
            };
        }

        public bool HasDepartmentsByLibraryId(int libraryId)
        {
            return departmentRepository.Any(w => w.LibraryId == libraryId);
        }

        public ServiceResult AddDepartment(DepartmentViewModel entity)
        {
            departmentRepository.Add(new Department
            {
                Name = entity.Name,
                LibraryId = entity.LibraryId
            });

            return ServiceResult.GetAddResult(uow.Commit() == 1);
        }

        public ServiceResult UpdateDepartment(DepartmentViewModel entity)
        {
            departmentRepository.Update(new Department
            {
                Id = entity.Id.Value,
                Name = entity.Name,
                LibraryId = entity.LibraryId
            });

            return ServiceResult.GetUpdateResult(uow.Commit() == 1);
        }

        public ServiceResult RemoveDepartment(int id, bool cascadeRemove = false)
        {
            if(cascadeRemove)
            {
                // TODO: Cascade remove
            }

            departmentRepository.Delete(id);

            return ServiceResult.GetRemoveResult(uow.Commit() > 0);
        }
    }
}
