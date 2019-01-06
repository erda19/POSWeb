using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSWeb.Web.Helper
{
    public class Datatables
    {

        public static Dictionary<string, StringValues> SetParameters(HttpRequest Request)
        {
            var parse = System.Web.HttpUtility.ParseQueryString(Request.QueryString.ToString());
            var param = parse.AllKeys.Select(key => new {
                Name = key.ToString()
                    ,
                Value = Request.Query[key.ToString()]
            })
                     .ToDictionary(t => t.Name, t => t.Value);

            return param;
        }

    }
}
