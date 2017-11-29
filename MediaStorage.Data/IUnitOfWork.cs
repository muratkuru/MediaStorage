using System;
using System.Threading.Tasks;

namespace MediaStorage.Data
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;

        int Commit();

        int SaveChanges();

        Task<int> SaveChangesAsync();

        //TODO: implement idisposable
    }
}
