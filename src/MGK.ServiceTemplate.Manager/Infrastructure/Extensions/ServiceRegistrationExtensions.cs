using MGK.ServiceBase.Services.Infrastructure.Extensions;
using MGK.ServiceTemplate.DataAccess.Infrastructure.Extensions;
using MGK.ServiceTemplate.Manager.SeedWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MGK.ServiceTemplate.Manager.Infrastructure.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static void AddManagerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabaseServices(configuration);
            services.AddServicesInAssembly<IManagerService>(configuration);
        }
    }
}
