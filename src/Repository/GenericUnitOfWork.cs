using POSWeb.Data.Models;
using Microsoft.EntityFrameworkCore.Storage;
using POSWeb.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POSWeb.Repository
{
    public class GenericUnitOfWork : IGenericUnitOfWork, IDisposable
    {
        private readonly SalesDbContext _context;
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        private IDbContextTransaction _transaction;
        public GenericUnitOfWork(SalesDbContext dbContext)
        {
            this._context = dbContext;
        }
        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IGenericRepository<T>;
            }
            IGenericRepository<T> repo = new GenericRepository<T>(_context);
            repositories.Add(typeof(T), repo);
            return repo;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
        public long SaveChanges()
        {
            return _context.SaveChanges();
        }

        private bool disposed = false;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
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

    }
}
