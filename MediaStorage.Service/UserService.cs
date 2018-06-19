using MediaStorage.Common;
using MediaStorage.Common.ViewModels.User;
using MediaStorage.Data;
using MediaStorage.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MediaStorage.Service
{
    public interface IUserService
    {
        ICollection<UserViewModel> GetAllUsers();

        UserPostViewModel GetUserById(Guid id);

        ServiceResult Login(LoginViewModel model);

        ServiceResult AddUser(UserPostViewModel entity);

        ServiceResult UpdateUser(UserPostViewModel entity);

        ServiceResult RemoveUser(Guid id);
    }

    public class UserService : IUserService
    {
        private IUnitOfWork uow;
        private IRepository<User> userRepository;
        private IUserRoleService userRoleService;

        public UserService(IRepository<User> userRepository, IUserRoleService userRoleService, IUnitOfWork uow)
        {
            this.uow = uow;
            this.userRepository = userRepository;
            this.userRoleService = userRoleService;
        }

        public ICollection<UserViewModel> GetAllUsers()
        {
            return userRepository.GetAll()
                .Select(s => new UserViewModel
                {
                    Id = s.Id.ToString(),
                    Username = s.Username,
                    Mail = s.Mail,
                    IsActive = s.IsActive
                }).ToList();
        }

        public UserPostViewModel GetUserById(Guid id)
        {
            var user = userRepository.Find(id);
            return user == null ? null : new UserPostViewModel
            {
                Id = user.Id,
                Username = user.Username,
                Mail = user.Mail
            };
        }

        public ServiceResult Login(LoginViewModel model)
        {
            ServiceResult result = new ServiceResult();
            var user = userRepository.Get(w => w.Username == model.Username && w.Password == model.Password);
            if (user == null)
                result.SetFailure("User not found.");
            else
                result.SetSuccess("Login successful.");

            return result;
        }

        public ServiceResult AddUser(UserPostViewModel entity)
        {
            var userRoles = userRoleService.GetUserRolesByIds(entity.UserRoleIds);
            // TODO: Send mail
            var password = CreateRandomPassword();

            if (userRepository.Get(w => w.Username == entity.Username) != null)
                return new ServiceResult(false, "Username already exist.");
            if (userRepository.Get(w => w.Mail == entity.Mail) != null)
                return new ServiceResult(false, "Mail already exist.");

            userRepository.Add(new User
            {
                Username = entity.Username,
                Mail = entity.Mail,
                UserRoles = userRoles,
                Password = password,
                IsActive = entity.IsActive
            });

            return ServiceResult.GetAddResult(uow.Commit() > 0);
        }

        public ServiceResult UpdateUser(UserPostViewModel entity)
        {
            var userRoles = userRoleService.GetUserRolesByIds(entity.UserRoleIds);
            // TODO: Send mail
            var password = CreateRandomPassword();

            var user = userRepository.Get(w => w.Id == entity.Id, i => i.UserRoles);

            if (user.Username != entity.Username)
                if (userRepository.Get(w => w.Username == entity.Username) != null)
                    return new ServiceResult(false, "Username already exist.");
            if (user.Mail != entity.Mail)
                if (userRepository.Get(w => w.Mail == entity.Mail) != null)
                    return new ServiceResult(false, "Mail already exist.");

            user.Username = entity.Username;
            user.Mail = entity.Mail;
            user.UserRoles = userRoles;
            user.IsActive = entity.IsActive;

            userRepository.Update(user);

            return ServiceResult.GetUpdateResult(uow.Commit() > 0);
        }

        public ServiceResult RemoveUser(Guid id)
        {
            var user = userRepository.Get(w => w.Id == id, i => i.UserRoles);
            if (user != null)
                userRepository.Delete(user);

            return ServiceResult.GetRemoveResult(uow.Commit() > 0);
        }

        // TODO: Refactoring
        private string CreateRandomPassword()
        {
            string charachters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPRSTUVWXYZ0123456789*!+-_.";
            Random random = new Random();
            string password = string.Empty;

            for (int i = 0; i < 16; i++)
            {
                int randomIndex = random.Next(0, charachters.Length);
                password += charachters[randomIndex];
            }

            return password;
        }
    }
}
