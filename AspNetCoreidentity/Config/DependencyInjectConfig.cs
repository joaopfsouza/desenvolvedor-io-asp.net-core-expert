using AspNetCoreidentity.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreidentity.Config
{
    public static class DependencyInjectConfig
    {
        public static IServiceCollection ResolveDependencies (this IServiceCollection services)
        {

            services.AddSingleton<IAuthorizationHandler, PermissaoNecessariaHandler>();

            return services;
        }
    }
}
