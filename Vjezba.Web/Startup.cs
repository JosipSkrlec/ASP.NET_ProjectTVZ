using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using Vjezba.DAL;
using Vjezba.Model;

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

            services.AddDbContext<ClientManagerDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("ClientManagerDbContext"),
                    opt => opt.MigrationsAssembly("Vjezba.DAL")));

            /*services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ClientManagerDbContext>();*/
            services.AddIdentity<AppUser, IdentityRole>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ClientManagerDbContext>();

            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();

            services.AddAuthentication().AddGoogle(opt =>
            {
                opt.ClientId = "930756123504-3pum46ta993gpj486eks2qeviebovaps.apps.googleusercontent.com";
                opt.ClientSecret = "Xdr0KdhALmPoi8HRayj-c8vh";
            });
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

            app.UseAuthentication();
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

                endpoints.MapRazorPages();
            });

            var supportedCultures = new[]
            {
                new CultureInfo("hr"), new CultureInfo("en-US")
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("hr"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            
        }
    }
}
