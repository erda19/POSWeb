﻿using SalesApp.Data.Models;
using SalesApp.Repository.Interface;
using SalesApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace SalesApp.Services
{
    public class ServiceProductCategory : IServiceProductCategory
    {
        private readonly IGenericUnitOfWork _genericUnitOfWork;
        public ServiceProductCategory(IGenericUnitOfWork genericUnitOfWork)
        {
            _genericUnitOfWork = genericUnitOfWork;
        }

        public IList<MsProductcategory> GetCategory()
        {
           return _genericUnitOfWork.GenericRepository<MsProductcategory>().Get();
        }

        public void InsertProductCategory(MsProductcategory category)
        {
            var a = _genericUnitOfWork.GenericRepository<MsProductcategory>()
                        .Get(x=>x.IsActive == true
                        , orderBy: mt => mt.OrderBy(x=>x.ModifiedBy)
                        );
            _genericUnitOfWork.GenericRepository<MsProductcategory>().Insert(category);
        }

    }
}
