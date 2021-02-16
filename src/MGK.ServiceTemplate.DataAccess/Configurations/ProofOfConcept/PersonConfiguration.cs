using MGK.ServiceBase.DAL.Infrastructure.Extensions;
using MGK.ServiceTemplate.DataAccess.Models.ProofOfConcept;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MGK.ServiceTemplate.DataAccess.Configurations.ProofOfConcept
{
	public class PersonConfiguration : IEntityTypeConfiguration<Person>
	{
		public void Configure(EntityTypeBuilder<Person> builder)
		{
			builder.SetupBaseEntity<Person, Guid>();

			builder.Property(p => p.Id).IsRequired();
			builder.Property(p => p.BirthDate).IsRequired();
			builder.Property(p => p.Name).HasMaxLength(255).IsRequired();
			builder.Property(p => p.Surname).HasMaxLength(255).IsRequired();
		}
	}
}
