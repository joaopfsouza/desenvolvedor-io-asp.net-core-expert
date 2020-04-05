using AspNetCoreidentity.Areas.Identity.Data;
using AspNetCoreidentity.Config;
using AspNetCoreidentity.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetCoreidentity
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

    
        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.config", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.config",true,true)
                .AddEnvironmentVariables();


            if (hostEnvironment.IsProduction())
            {
                builder.AddUserSecrets<Startup>();
            }


            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {

            #region Config

            services.AddIdentiyConfig(Configuration);
            services.AddAutorizathionConfig();
            services.ResolveDependencies();
            #endregion


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
