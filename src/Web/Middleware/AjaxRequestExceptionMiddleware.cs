using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using POSWeb.Web.ApiModels;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace POSWeb.Middleware
{
    public class AjaxRequestExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly ILoggerManager _logger;

        public AjaxRequestExceptionMiddleware(RequestDelegate next)
        {
            //_logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                try
                {
                    await _next(httpContext);
                }
                catch (Exception ex)
                {
                    await HandleExceptionAsync(httpContext, ex);
                }
            }
            else
            {
                await _next(httpContext);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string result = JsonConvert.SerializeObject(new ApiResponse
            {
                Status = context.Response.StatusCode,
                Message = "Internal Server Error"
            });
            return context.Response.WriteAsync(result, Encoding.UTF8);
        }


    }
}
