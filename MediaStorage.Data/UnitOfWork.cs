using System;
using System.Threading.Tasks;

namespace MediaStorage.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MediaContext context;

        public UnitOfWork(MediaContext context)
        {
            this.context = context ?? throw new ArgumentNullException("Context can not be null.");
        }

        public int Commit()
        {
            int commitCount = -1;
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var saveChanges = SaveChangesAsync();

                    transaction.Commit();

                    commitCount = saveChanges.Result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }

            return commitCount;
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }

        #region IDisposable implementation
        /*
         * DbContext has been disposed error on IDisposable pattern.
         */
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (disposed == false)
                if (disposing)
                    if (context != null)
                        context.Dispose();

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
