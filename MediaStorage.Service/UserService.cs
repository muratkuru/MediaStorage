using MediaStorage.Common;
using MediaStorage.Common.ViewModels.User;
using MediaStorage.Data;
using MediaStorage.Data.Entities;

namespace MediaStorage.Service
{
    public interface IAdministratorService
    {
        ServiceResult Login(LoginViewModel model);
    }

    public class UserService : IAdministratorService
    {
        private IRepository<User> userRepository;

        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
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
    }
}
