using System;
using System.Collections.Generic;
using System.Text;

namespace POSWeb.Common.WebApi
{
    public class ApiResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object Result { get; set; } = null;
    }
}
