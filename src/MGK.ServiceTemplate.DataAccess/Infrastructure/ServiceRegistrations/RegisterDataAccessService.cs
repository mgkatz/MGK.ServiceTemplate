using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MGK.ServiceBase.DAL.Infrastructure.Extensions;
using MGK.ServiceBase.SeedWork;
using MGK.ServiceTemplate.DataAccess.Contexts;
using MGK.ServiceTemplate.DataAccess.Infrastructure.Enums;
using MGK.ServiceTemplate.DataAccess.Infrastructure.Extensions;
using MGK.ServiceTemplate.DataAccess.Infrastructure.Queries.ProofOfConcept;
using MGK.ServiceTemplate.DataAccess.Infrastructure.UnitOfWork;
using MGK.ServiceTemplate.DataAccess.Queries.ProofOfConcept;
using MGK.ServiceTemplate.DataAccess.UnitOfWork;

namespace MGK.ServiceTemplate.DataAccess.Infrastructure.ServiceRegistrations
{
    public class RegisterDataAccessService : IServiceRegistration
    {
        public void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            RegisterProofOfConceptServices(services);

            services.RunDbMigrations();
        }

        private void RegisterProofOfConceptServices(IServiceCollection services)
        {
            services.AddDbContext<ProofOfConceptContext>(nameof(AvailableDatabase.ProofOfConcept));
            services.AddScoped<IProofOfConceptUoW, ProofOfConceptUoW>();
            services.AddScoped<IPersonQueryBuilder, PersonQueryBuilder>();
        }
    }
}
