using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace middleware
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession();                     
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        { 
            app.UseStaticFiles();
            app.UseSession();
            app.UseMiddleware<CheckAcessMiddleware>();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapMethods("/Testpost" , new string[] {"post", "put"}, async context => {
                    await context.Response.WriteAsync("post/pust");
                });

                endpoints.MapGet("/Home", async context => {

                    int? count  = context.Session.GetInt32("count");
                    count = (count != null) ? count + 1 : 1;
                    context.Session.SetInt32("count", count.Value);
                    await context.Response.WriteAsync($"Home page! {count}");

                });
            });

            app.Run(async context  => {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync("Page not found");
            });
        }
    }
}