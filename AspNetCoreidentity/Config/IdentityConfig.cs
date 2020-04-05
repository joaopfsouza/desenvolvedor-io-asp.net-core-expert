using AspNetCoreidentity.Areas.Identity.Data;
using AspNetCoreidentity.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreidentity.Config
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddAutorizathionConfig(this IServiceCollection services)
        {

            services.AddAuthorization(options =>
            {
                options.AddPolicy("PodeExcluir", policy => policy.RequireClaim("PodeExcluir"));

                options.AddPolicy("PodeLer", policy => policy.Requirements.Add(new PermissaoNecessaria("PodeLer")));
                options.AddPolicy("PodeEscrever", policy => policy.Requirements.Add(new PermissaoNecessaria("PodeEscrever")));
                options.AddPolicy("PodeGravar", policy => policy.Requirements.Add(new PermissaoNecessaria("PodeGravar")));
            });

            return services;
        }



        public static IServiceCollection AddIdentiyConfig(this IServiceCollection services, IConfiguration configuration)
        {

            //services.AddDbContext<AspNetCoreidentityContext>(options =>
            //           options.UseSqlServer(
            //               configuration.GetConnectionString("AspNetCoreidentityContextConnection")));



            services.AddControllersWithViews();



            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddDefaultUI()
                .AddEntityFrameworkStores<AspNetCoreidentityContext>();

            return services;
        }
    }
}

