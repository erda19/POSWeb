using POSWeb.Data.Models;
using Microsoft.EntityFrameworkCore;
using POSWeb.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POSWeb.Repository
{
    class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
    {
        private readonly SalesDbContext _context;
        private DbSet<T> _dbSet;
        public GenericRepository(SalesDbContext context)
        {
            this._context = context;
            this._dbSet = context.Set<T>();
        }
        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }
        public List<T> Get(
            Expression<Func<T, bool>> filter = null
            , Func<IQueryable<T>,IOrderedQueryable<T>> orderBy = null
            , params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query.ToList();
        }

        public virtual async Task<T> GetById(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);
            return query.FirstOrDefault(filter);
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IQueryable<T> AsQueryAble()
        {
            return _dbSet.AsQueryable();
        }
    }
}
