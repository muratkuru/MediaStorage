﻿using MediaStorage.Common;
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

        ICollection<CustomSelectListItem> GetAllUserRolesBySelectListItem(int? menuItemId);

        UserRoleViewModel GetUserRoleById(int id);

        ServiceResult AddOrUpdateUserRole(UserRoleViewModel entity);

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

        public ICollection<CustomSelectListItem> GetAllUserRolesBySelectListItem(int? menuItemId)
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

        public UserRoleViewModel GetUserRoleById(int id)
        {
            var userRole = userRoleRepository.Find(id);
            return userRole == null ? null : new UserRoleViewModel
            {
                Id = userRole.Id,
                Name = userRole.Name
            };
        }


        public ServiceResult AddOrUpdateUserRole(UserRoleViewModel entity)
        {
            if (entity.Id.HasValue)
            {
                userRoleRepository.Update(new UserRole
                {
                    Id = entity.Id.Value,
                    Name = entity.Name
                });
            }
            else
            {
                userRoleRepository.Add(new UserRole
                {
                    Name = entity.Name
                });
            }

            string message = entity.Id.HasValue
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
