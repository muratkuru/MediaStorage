using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MediaStorage.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MediaContext context;
        private readonly DbSet<T> dbSet;

        public Repository(MediaContext context)
        {
            this.context = context ?? throw new ArgumentNullException("Context can not be null.");
            dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void AddRange(ICollection<T> entities)
        {
            dbSet.AddRange(entities);
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Count(predicate);
        }

        public int Count()
        {
            return dbSet.Count();
        }

        public Task<int> CountAsync()
        {
            return dbSet.CountAsync();
        }

        public Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return dbSet.CountAsync(predicate);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Delete(object id)
        {
            dbSet.Remove(
                Find(id)
            );
        }

        public void DeleteAll(Expression<Func<T, bool>> predicate)
        {
            dbSet.RemoveRange(
                GetAll(predicate)
            );
        }

        public void DeleteRange(ICollection<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public T Find(object key)
        {
            return dbSet.Find(key);
        }

        public Task<T> FindAsync(object key)
        {
            return dbSet.FindAsync(key);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return dbSet.FirstOrDefault(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return dbSet.FirstOrDefaultAsync(predicate);
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
