using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MediaStorage.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes);

        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        T Get(Expression<Func<T, bool>> predicate);

        T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        Task<T> GetAsync(Expression<Func<T, bool>> predicate);

        T Find(object key);

        Task<T> FindAsync(object key);

        bool Any(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void AddRange(ICollection<T> entities);

        void Update(T entity);

        void Delete(T entity);

        void Delete(object id);

        void DeleteRange(ICollection<T> entities);

        void DeleteAll(Expression<Func<T, bool>> predicate);

        int Count();

        int Count(Expression<Func<T, bool>> predicate);

        Task<int> CountAsync();

        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
    }

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
            var entity = Find(id);
            if(entity != null)
                dbSet.Remove(entity);
        }

        public void DeleteAll(Expression<Func<T, bool>> predicate)
        {
            var entities = GetAll(predicate).ToList();
            if(entities.Count > 0)
                dbSet.RemoveRange(entities);
        }

        public void DeleteRange(ICollection<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Any(predicate);
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

        public T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {   
            return GetAll(includes).FirstOrDefault(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            var query = dbSet.AsQueryable();

            if(includes != null)
            {
                foreach (var item in includes)
                    query = query.Include(item);
            }

            return query;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return GetAll(includes).Where(predicate);
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
