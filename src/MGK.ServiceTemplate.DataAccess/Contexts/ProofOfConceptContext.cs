using MGK.ServiceBase.DAL;
using MGK.ServiceBase.DAL.Infrastructure.Extensions;
using MGK.ServiceBase.DAL.Infrastructure.Factories;
using MGK.ServiceTemplate.DataAccess.Infrastructure.Configurations;
using MGK.ServiceTemplate.DataAccess.Infrastructure.Enums;
using MGK.ServiceTemplate.DataAccess.Models.ProofOfConcept;
using Microsoft.EntityFrameworkCore;

namespace MGK.ServiceTemplate.DataAccess.Contexts
{
    public class ProofOfConceptContext : CustomDbContext
    {
        public ProofOfConceptContext(DbContextOptions<ProofOfConceptContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConventions()
                .ApplyConfigurationsFromAssembly(GetType().Assembly, typeof(IProofOfConceptConfiguration));
        }
    }

    public class ProofOfConceptContextDesignFactory : CustomDbContextDesignFactory<ProofOfConceptContext>
    {
        protected override string AppSettingsFile => "appsettings.local.json";

        protected override string DbName => nameof(AvailableDatabase.ProofOfConcept);
    }
}
