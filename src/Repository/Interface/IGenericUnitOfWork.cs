using SalesApp.Data.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesApp.Repository.Interface
{
    public interface IGenericUnitOfWork
    {
        IGenericRepository<T> GenericRepository<T>() where T : class;
        IDbContextTransaction BeginTransaction();
        Int64 SaveChanges();
    }
}
