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

        ICollection<CustomSelectListItem> GetAllUserRolesByMenuItemId(int? menuItemId);

        ICollection<CustomSelectListItem> GetAllUserRolesByUserId(string userId);

        ICollection<UserRole> GetUserRolesByIds(int[] ids);

        UserRoleViewModel GetUserRoleById(int id);

        ServiceResult AddUserRole(UserRoleViewModel entity);

        ServiceResult UpdateUserRole(UserRoleViewModel entity);

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
            return userRoleRepository.GetAll()
                .Select(s => new UserRoleViewModel
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToList();
        }

        public ICollection<CustomSelectListItem> GetAllUserRolesByMenuItemId(int? menuItemId)
        {
            return userRoleRepository.GetAll()
                .Select(s => new CustomSelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name,
                    Selected = menuItemId.HasValue 
                        ? s.MenuItems.Any(w => w.Id == menuItemId) 
                        : false
                }).ToList();
        }

        public ICollection<CustomSelectListItem> GetAllUserRolesByUserId(string userId)
        {
            return userRoleRepository.GetAll()
                .Select(s => new CustomSelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name,
                    Selected = string.IsNullOrEmpty(userId)
                        ? false
                        : s.Users.Any(w => w.Id.ToString() == userId)
                }).ToList();
        }

        public ICollection<UserRole> GetUserRolesByIds(int[] ids)
        {
            var userRoles = new List<UserRole>();
            if(ids != null)
                foreach(var item in ids)
                {
                    var userRole = userRoleRepository.Find(item);
                    if (userRole != null)
                        userRoles.Add(userRole);
                }

            return userRoles;

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

        public ServiceResult AddUserRole(UserRoleViewModel entity)
        {
            userRoleRepository.Add(new UserRole
            {
                Name = entity.Name
            });

            return ServiceResult.GetAddResult(uow.Commit() == 1);
        }

        public ServiceResult UpdateUserRole(UserRoleViewModel entity)
        {
            userRoleRepository.Update(new UserRole
            {
                Id = entity.Id.Value,
                Name = entity.Name
            });

            return ServiceResult.GetUpdateResult(uow.Commit() == 1);
        }

        public ServiceResult RemoveUserRole(int id)
        {
            userRoleRepository.Delete(id);

            return ServiceResult.GetRemoveResult(uow.Commit() == 1);
        }
    }
}
