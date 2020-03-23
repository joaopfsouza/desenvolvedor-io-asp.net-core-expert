using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevIO.UI.Site.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DevIO.UI.Site
{
    public class Startup
    {


        public IConfiguration Configuration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/Shared/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            });


            services.AddDbContext<MeuDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MeuDbContext")));

            services.AddTransient<IPedidoRepository, PedidoRepository>();
           
            
            services.AddRazorPages();


           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute("areas", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute("AreasProdutos","Produtos", "Produtos/{controller=Cadastro}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute("AreasVendas","Vendas", "Vendas/{controller=Pedidos}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("defaut", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
