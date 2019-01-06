using POSWeb.Data.Models;
using POSWeb.Repository.Interface;
using POSWeb.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataTablesParser;
using Microsoft.Extensions.Primitives;

namespace POSWeb.Services
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

        public object ViewGrid(IEnumerable<KeyValuePair<string, StringValues>>  param)
        {
            var data = _genericUnitOfWork.GenericRepository<MsProductcategory>()
                        .AsQueryAble();
            var parser = new Parser<MsProductcategory>(param,data);
            return parser.Parse();
        }
    }
}
