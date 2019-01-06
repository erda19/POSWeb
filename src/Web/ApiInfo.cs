using Microsoft.OpenApi.Models;

namespace POSWeb.Web
{
    internal class ApiInfo : OpenApiInfo
    {
        public string Title { get; set; }
        public string Version { get; set; }
    }
}