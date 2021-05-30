using MGK.ServiceBase.Services.Infrastructure.Extensions;
using MGK.ServiceBase.Services.SeedWork;
using MGK.ServiceTemplate.Manager.Infrastructure.ServiceProviders;
using MGK.ServiceTemplate.Manager.Infrastructure.Services.ProofOfConcept;
using MGK.ServiceTemplate.Manager.SeedWork;
using MGK.ServiceTemplate.Manager.Services.Base;
using MGK.ServiceTemplate.Manager.Services.ProofOfConcept;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace MGK.ServiceTemplate.Manager.Infrastructure.ServiceRegistrations
{
    public class RegisterManagerService : IServiceRegistration
    {
        public void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDataAccessServiceProvider, DataAccessServiceProvider>();
            services.AddScoped(typeof(IManagerInternalServices<>), typeof(ManagerInternalServices<>));
            AddManagerServices(services);
        }

        private static void AddManagerServices(IServiceCollection services)
        {
            var managerServices = new Dictionary<string, Type>
            {
                { nameof(IPersonService), typeof(PersonService) }
			};

            services.AddKeyedServices<IManagerService, string>(managerServices);
        }
    }
}
