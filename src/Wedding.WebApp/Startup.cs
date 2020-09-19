using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Wedding.WebApp
{
    internal sealed class Startup
    {
        private readonly IConfiguration _configuration;

        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }        
        
        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWebOptimizer(pipeline =>
            {
                pipeline.MinifyJsFiles();
                pipeline.CompileScssFiles();
            });
        }

        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseWebOptimizer();

            app.UseDefaultFiles();

            app.UseStaticFiles();

            app.UseRouting();

            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapGet("/", async context =>
            //     {
            //         await context.Response.WriteAsync("Hello World!");
            //     });
            // });
        }
    }
}
