using MediaStorage.Common;
using MediaStorage.Common.ViewModels.Administrator;
using MediaStorage.Data;
using MediaStorage.Data.Entities;

namespace MediaStorage.Service
{
    public interface IAdministratorService
    {
        ServiceResult Login(LoginViewModel model);
    }

    public class AdministratorService : IAdministratorService
    {
        private IRepository<Administrator> administratorRepository;

        public AdministratorService(IRepository<Administrator> administratorRepository)
        {
            this.administratorRepository = administratorRepository;
        }

        public ServiceResult Login(LoginViewModel model)
        {
            ServiceResult result = new ServiceResult();
            var administrator = administratorRepository.Get(w => w.Username == model.Username && w.Password == model.Password);
            if (administrator == null)
                result.SetFailure("Administrator doesn't found.");
            else
                result.SetSuccess("Login successful.");

            return result;
        }
    }
}
