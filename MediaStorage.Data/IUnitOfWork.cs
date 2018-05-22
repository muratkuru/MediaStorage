using System;
using System.Threading.Tasks;

namespace MediaStorage.Data
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
