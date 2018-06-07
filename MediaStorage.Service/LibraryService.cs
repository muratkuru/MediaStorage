using MediaStorage.Common;
using MediaStorage.Common.ViewModels.Library;
using MediaStorage.Data;
using MediaStorage.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MediaStorage.Service
{
    public interface ILibraryService
    {
        ICollection<LibraryViewModel> GetAllLibraries();

        ICollection<CustomSelectListItem> GetLibrariesAsSelectListItem(int? departmentId);

        LibraryViewModel GetLibraryById(int id);

        ServiceResult AddLibrary(LibraryViewModel entity);

        ServiceResult UpdateLibrary(LibraryViewModel entity);

        ServiceResult RemoveLibrary(int id, bool cascadeRemove = false);
    }

    public class LibraryService : ILibraryService
    {
        private IUnitOfWork uow;
        private IRepository<Library> libraryRepository;
        private IRepository<Department> departmentRepository;

        public LibraryService(IUnitOfWork uow, IRepository<Library> libraryRepository, IRepository<Department> departmentRepository)
        {
            this.uow = uow;
            this.libraryRepository = libraryRepository;
            this.departmentRepository = departmentRepository;
        }

        public ICollection<LibraryViewModel> GetAllLibraries()
        {
            return libraryRepository
                .GetAll()
                .Select(s => new LibraryViewModel
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToList();
        }

        public ICollection<CustomSelectListItem> GetLibrariesAsSelectListItem(int? departmentId)
        {
            return libraryRepository
                .GetAll()
                .Select(s => new CustomSelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name,
                    Selected = departmentId.HasValue 
                        ? s.Departments.Any(w => w.Id == departmentId)
                        : false
                }).ToList();
        }

        public LibraryViewModel GetLibraryById(int id)
        {
            var library = libraryRepository.Find(id);

            return library == null ? null : new LibraryViewModel
            {
                Id = library.Id,
                Name = library.Name
            };
        }

        public ServiceResult AddLibrary(LibraryViewModel entity)
        {
            libraryRepository.Add(new Library
            {
                Name = entity.Name
            });

            return ServiceResult.GetAddResult(uow.Commit() == 1);
        }

        public ServiceResult UpdateLibrary(LibraryViewModel entity)
        {
            libraryRepository.Update(new Library
            {
                Id = entity.Id.Value,
                Name = entity.Name
            });

            return ServiceResult.GetUpdateResult(uow.Commit() == 1);
        }

        public ServiceResult RemoveLibrary(int id, bool cascadeRemove = false)
        {
            if(cascadeRemove)
            {
                var departments = departmentRepository.GetAll(w => w.LibraryId == id).ToList();
                if (departments.Count > 0)
                    departmentRepository.DeleteRange(departments);
            }

            libraryRepository.Delete(id);

            return ServiceResult.GetRemoveResult(uow.Commit() > 0);
        }
    }
}
