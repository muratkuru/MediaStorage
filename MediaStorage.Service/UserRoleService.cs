using MediaStorage.Common;
using MediaStorage.Common.ViewModels.UserRole;
using MediaStorage.Data;
using MediaStorage.Data.Entities;

namespace MediaStorage.Service
{
    public interface IUserRoleService
    {
        ServiceResult AddOrUpdate(UserRolePostViewModel model);
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
        
        public ServiceResult AddOrUpdate(UserRolePostViewModel model)
        {
            if (model.Id.HasValue)
            {
                var user = userRoleRepository.Find(model.Id.Value);
                if (user == null)
                    return new ServiceResult(false, "There is no User Role for this ID.");

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
    }
}
