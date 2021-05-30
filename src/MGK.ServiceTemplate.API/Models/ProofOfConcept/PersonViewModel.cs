using MGK.ServiceBase.CQRS.SeedWork;
using MGK.ServiceTemplate.API.Infrastructure.Contracts.ProofOfConcept;
using System;

namespace MGK.ServiceTemplate.API.Models.ProofOfConcept
{
	public class PersonViewModel : IPersonContract, IResponse
	{
		public Guid PersonId { get; set; }

		public string Name { get; set; }

		public string Surname { get; set; }

		public string DocumentNumber { get; set; }

		public DateTime BirthDate { get; set; }

		public DateTime CreationDate { get; set; }

		public DateTime? LastUpdateDate { get; set; }
	}
}
