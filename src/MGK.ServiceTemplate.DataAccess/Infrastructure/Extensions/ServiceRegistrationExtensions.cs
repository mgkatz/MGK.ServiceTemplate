using MGK.ServiceBase.DAL.Infrastructure.Extensions;
using MGK.ServiceBase.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MGK.ServiceTemplate.DataAccess.Infrastructure.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static void AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDALServices(configuration);
            services.AddServicesInAssembly<MappingProfile>(configuration);
        }
    }
}
