using MGK.ServiceBase.Infrastructure.Extensions;
using MGK.ServiceBase.SeedWork;
using MGK.ServiceTemplate.Manager.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MGK.ServiceTemplate.API.Infrastructure.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IServiceParameters, ServiceParameters>();
            services.AddBaseServices(configuration);
            services.AddManagerServices(configuration);
            services.AddServicesInAssembly<Startup>(configuration);
        }
    }
}
