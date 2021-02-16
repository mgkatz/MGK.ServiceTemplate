using MGK.ServiceBase.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace MGK.ServiceTemplate.API.Infrastructure.Extensions
{
    public static class AppBuilderExtensions
    {
        public static void AddAppConfigurations(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.AddBaseAppConfigurations(configuration);
            app.AddAppConfigurationsInAssembly<Startup>(configuration);
        }
    }
}
