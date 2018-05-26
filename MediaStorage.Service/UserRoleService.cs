using MediaStorage.Common;
using MediaStorage.Common.ViewModels.UserRole;
using MediaStorage.Data;
using MediaStorage.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MediaStorage.Service
{
    public interface IUserRoleService
    {
        ICollection<UserRoleViewModel> GetAllUserRoles();

        UserRoleViewModel GetUserRoleById(int id);

        ServiceResult AddOrUpdateUserRole(UserRoleViewModel model);

        ServiceResult RemoveUserRole(int id);
    }

    public class UserRoleService : IUserRoleService
    {
        private IUnitOfWork uow;
        private IRepository<UserRole> userRoleRepository;

        public UserRoleService(IUnitOfWork uow, IRepository<UserRole> userRoleRepository)
        {
            this.uow = uow;
            this.userRoleRepository = userRoleRepository;
        }

        public ICollection<UserRoleViewModel> GetAllUserRoles()
        {
            return userRoleRepository.GetAll().Select(s => new UserRoleViewModel
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();
        }

        public UserRoleViewModel GetUserRoleById(int id)
        {
            var userRole = userRoleRepository.Find(id);
            return userRole == null ? null : new UserRoleViewModel
            {
                Id = userRole.Id,
                Name = userRole.Name
            };
        }


        public ServiceResult AddOrUpdateUserRole(UserRoleViewModel model)
        {
            if (model.Id.HasValue)
            {
                userRoleRepository.Update(new UserRole
                {
                    Id = model.Id.Value,
                    Name = model.Name
                });
            }
            else
            {
                userRoleRepository.Add(new UserRole
                {
                    Name = model.Name
                });
            }

            string message = model.Id.HasValue
                ? "The update process has "
                : "The add process has ";

            return uow.Commit() == 1
                ? new ServiceResult(true, message + "successful.")
                : new ServiceResult(false, message + "been unsuccessful.");
        }

        public ServiceResult RemoveUserRole(int id)
        {
            userRoleRepository.Delete(id);

            return uow.Commit() == 1
                ? new ServiceResult(true, "The remove process has successful.")
                : new ServiceResult(false, "The remove process has been unsuccessful.");
        }
    }
}
