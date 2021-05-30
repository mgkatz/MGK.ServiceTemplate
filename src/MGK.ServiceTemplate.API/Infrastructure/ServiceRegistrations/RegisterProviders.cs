using MGK.ServiceBase.Services.SeedWork;
using MGK.ServiceTemplate.API.Infrastructure.ServiceProviders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MGK.ServiceTemplate.API.Infrastructure.ServiceRegistrations
{
    public class RegisterProviders : IServiceRegistration
    {
        public void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IManagerServiceProvider, ManagerServiceProvider>();
		}
    }
}
