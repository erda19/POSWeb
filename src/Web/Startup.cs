using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POSWeb.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using POSWeb.Repository.Interface;
using POSWeb.Repository;
using POSWeb.Services.Interface;
using POSWeb.Services;
using Swashbuckle.AspNetCore.Swagger;
using VMD.RESTApiResponseWrapper.Core.Extensions;
using Newtonsoft.Json.Serialization;

namespace POSWeb.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDbContext<SalesDbContext>( // replace "YourDbContext" with the class name of your DbContext
                options => options.UseMySql(Configuration.GetSection("Data:DefaultConnectionString").Value, // replace with your Connection String
                    mysqlOptions =>
                    {
                        mysqlOptions.ServerVersion(new Version(8, 0, 13), ServerType.MySql); // replace with your Server Version and Type
                    }
            ));

            services.AddScoped<IGenericUnitOfWork, GenericUnitOfWork>();

            AddScopeServices(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                 .AddJsonOptions(options =>
                 {
                     options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                 }); 



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new ApiInfo { Title = "My API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseAPIResponseWrapperMiddleware();

        }
               
        private void AddScopeServices(IServiceCollection services)
        {
            services.AddScoped<IServiceProductCategory, ServiceProductCategory>();
        }


    }
}
