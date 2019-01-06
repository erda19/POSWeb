using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using POSWeb.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POSWeb.Services.Interface
{
    public interface IServiceProductCategory
    {
        void InsertProductCategory(MsProductcategory category);
        IList<MsProductcategory> GetCategory();
        object ViewGrid(IEnumerable<KeyValuePair<string, StringValues>> param);
    }
}
