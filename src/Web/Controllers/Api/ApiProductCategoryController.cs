using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POSWeb.Services.Interface;
using POSWeb.Web.Helper;
namespace POSWeb.Web.Controllers.Api
{
    public class ApiProductCategoryController : ApiBaseController
    {
        private readonly IServiceProductCategory _serviceProductCategory;
        public ApiProductCategoryController(
            IServiceProductCategory serviceProductCategory)
        {
            _serviceProductCategory = serviceProductCategory;
        }

        [HttpGet(Name = "CheckMiddleware")]
        public IActionResult CheckMiddleware()
        {
            throw new Exception("test");
            //return Json(new ApiResponse { Message="", Status = 0, Result = null  });
        }

        [HttpGet(Name = "ViewGrid")]
        public IActionResult ViewGrid()
        {
            var data = _serviceProductCategory.ViewGrid(Datatables.SetParameters(Request));
            return Json(data);

        }
    }
}