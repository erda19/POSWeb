using Microsoft.OpenApi.Models;

namespace SalesApp.Web
{
    internal class ApiInfo : OpenApiInfo
    {
        public string Title { get; set; }
        public string Version { get; set; }
    }
}