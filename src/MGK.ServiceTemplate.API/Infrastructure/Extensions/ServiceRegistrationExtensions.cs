using MGK.ServiceBase.Configuration.SeedWork;
using MGK.ServiceBase.CQRS.Infrastructure.Extensions;
using MGK.ServiceBase.Infrastructure.Extensions;
using MGK.ServiceBase.Services.Infrastructure.Extensions;
using MGK.ServiceTemplate.Manager.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MGK.ServiceTemplate.API.Infrastructure.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IMicroServiceParameters, ServiceParameters>();
            services.AddCqrsServices(configuration);
            services.AddApiServices(configuration);
            services.AddManagerServices(configuration);
            services.AddServicesInAssembly<Startup>(configuration);
        }
    }
}
