using MGK.ServiceBase.DAL.Infrastructure.Extensions;
using MGK.ServiceBase.Services.Infrastructure.Extensions;
using MGK.ServiceBase.Services.SeedWork;
using MGK.ServiceTemplate.DataAccess.Contexts;
using MGK.ServiceTemplate.DataAccess.Infrastructure.Enums;
using MGK.ServiceTemplate.DataAccess.Infrastructure.Extensions;
using MGK.ServiceTemplate.DataAccess.Infrastructure.Queries.ProofOfConcept;
using MGK.ServiceTemplate.DataAccess.Infrastructure.UnitOfWork;
using MGK.ServiceTemplate.DataAccess.Queries.ProofOfConcept;
using MGK.ServiceTemplate.DataAccess.SeedWork;
using MGK.ServiceTemplate.DataAccess.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace MGK.ServiceTemplate.DataAccess.Infrastructure.ServiceRegistrations
{
    public class RegisterDataAccessService : IServiceRegistration
    {
        public void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            AddContexts(services);
            AddDataAccessServices(services);

            services.RunDbMigrations();
        }

        private static void AddContexts(IServiceCollection services)
        {
            services.AddDbContext<ProofOfConceptContext>(nameof(AvailableDatabase.ProofOfConcept));
        }

        private static void AddDataAccessServices(IServiceCollection services)
        {
            var queryConstructors = new Dictionary<string, Type>
            {
                // Query Constructors
                { nameof(IPersonQueryConstructor), typeof(PersonQueryConstructor) },
                // Units of Work
                { nameof(IProofOfConceptUoW), typeof(ProofOfConceptUoW) }
            };

            services.AddKeyedServices<IDataAccessService, string>(queryConstructors);
        }
    }
}
