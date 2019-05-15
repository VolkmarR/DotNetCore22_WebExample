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
using Swashbuckle.AspNetCore.Swagger;

namespace QuestionsApp.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuration for the Swagger Generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("QuestionsApi", new Info { Title = "Questions API" });
            });
            
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

            // activate swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/QuestionsApi/swagger.json", "Questions API V1");
            });

            // Activate MVC for Web-Api
            app.UseMvc();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Error!");
            });
        }
    }
}
