using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuestionsApp.Web.DB;

namespace QuestionsApp.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuration for the MVC Framework
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            // Configuration for Entity Framework
            services.AddDbContext<QuestionsContext>(options => options.UseInMemoryDatabase("Dummy"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Activate MVC for Web-Api
            app.UseMvc();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Error!");
            });
        }
    }
}
