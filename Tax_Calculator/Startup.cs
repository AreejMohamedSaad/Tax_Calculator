using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tax_Calculator.Interfaces;
using Tax_Calculator.Services;

namespace Tax_Calculator
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
            services.AddControllersWithViews();

            // add our dependency into the service collection which will dynamically inject whenever and wherever we want in the project.
            // singleton creates only single instances which will shared among all components that require it.
            services.AddSingleton<IVatServices, VatServices>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
           
            //app.UseEndpoints(endpoints =>
            //{
              //  endpoints.MapControllerRoute(
                //  name: "default",
                   // pattern: "{controller=Home}/{action=Index}/{id?}");
              //  endpoints.MapControllers(); //Routes for my API controllers
           // });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Calculator}/{action=Index}");
                endpoints.MapControllers(); //Routes for my API controllers
                    // pattern: "{controller=Calculator}/{action=Index}/{id?}");
            });
        }
    }
}
