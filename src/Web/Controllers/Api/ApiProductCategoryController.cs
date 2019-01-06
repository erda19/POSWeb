﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesApp.Services.Common;
using SalesApp.Services.Interface;
using VMD.RESTApiResponseWrapper.Core.Wrappers;

namespace SalesApp.Web.Controllers.Api
{
    public class ApiProductCategoryController : ApiBaseController
    {
        private readonly IServiceProductCategory _serviceProductCategory;
        public ApiProductCategoryController(IServiceProductCategory serviceProductCategory)
        {
            _serviceProductCategory = serviceProductCategory;
        }

        [HttpGet(Name = "Get")]
        public APIResponse Get()
        {
            try
            {
                var a = _serviceProductCategory.GetCategory().ToList();
            }
            catch(Exception e)
            {
                throw new ApiException("t");
            }
            //throw new ApiException("t");
            return new APIResponse(ApiStatus.Success, ApiResultMessage.Success, "");
        }
        

    }
}