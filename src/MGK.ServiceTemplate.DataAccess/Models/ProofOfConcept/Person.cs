using MGK.ServiceBase.DAL.Infrastructure.DataUnits;
using System;

namespace MGK.ServiceTemplate.DataAccess.Models.ProofOfConcept
{
	public class Person : AuditableDataUnit<Guid>
	{
		public string Name { get; set; }

		public string Surname { get; set; }

		public string DocumentNumber { get; set; }

		public DateTime BirthDate { get; set; }
	}
}
