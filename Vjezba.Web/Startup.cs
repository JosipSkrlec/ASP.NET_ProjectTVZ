using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
<<<<<<< HEAD
using Microsoft.AspNetCore.HttpsPolicy;
=======
>>>>>>> ca337c58b2cd131e98988edf6f40063ec79d1352
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
=======
>>>>>>> ca337c58b2cd131e98988edf6f40063ec79d1352
using Vjezba.DAL;

namespace Vjezba.Web
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
            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();

            services.AddDbContext<ClientManagerDbContext>(options =>
<<<<<<< HEAD
                options.UseSqlServer(
                    Configuration.GetConnectionString("ClientManagerDbContext"),
                    opt => opt.MigrationsAssembly("Vjezba.DAL")));
=======
             options.UseSqlServer(
             Configuration.GetConnectionString("ClientManagerDbContext"),
             opt => opt.MigrationsAssembly("Vjezba.DAL")));

    //        services.AddDbContext<LandingPageContext>(options =>
    //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
>>>>>>> ca337c58b2cd131e98988edf6f40063ec79d1352

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "kontakt-forma",
                    pattern: "kontakt-forma",
                    defaults: new { controller = "Home", action = "Contact" });

                endpoints.MapControllerRoute(
                    name: "o-aplikaciji",
                    pattern: "o-aplikaciji/{lang:alpha:length(2)}",
                    defaults: new { controller = "Home", action = "Privacy" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
<<<<<<< HEAD
=======

            //MockClientRepository.Instance.Initialize(Path.Combine(env.WebRootPath, "data"));
            //MockCityRepository.Instance.Initialize(Path.Combine(env.WebRootPath, "data"));
>>>>>>> ca337c58b2cd131e98988edf6f40063ec79d1352
        }
    }
}
