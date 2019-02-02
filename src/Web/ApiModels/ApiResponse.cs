using System;
using System.Collections.Generic;
using System.Text;

namespace POSWeb.Web.ApiModels
{
    public class ApiResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object Result { get; set; } = null;
    }
}
