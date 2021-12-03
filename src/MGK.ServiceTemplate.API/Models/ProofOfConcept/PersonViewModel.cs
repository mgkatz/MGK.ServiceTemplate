using MGK.ServiceBase.CQRS.SeedWork;
using MGK.ServiceTemplate.API.Infrastructure.Contracts.ProofOfConcept;
using System;

namespace MGK.ServiceTemplate.API.Models.ProofOfConcept
{
	public class PersonViewModel : IPersonContract, IResponse
	{
		public Guid PersonId { get; init; }

		public string Name { get; init; }

		public string Surname { get; init; }

		public string DocumentNumber { get; init; }

		public DateTime BirthDate { get; init; }

		public int Age { get; init; }

		public DateTime CreationDate { get; init; }

		public DateTime? LastUpdateDate { get; init; }
	}
}
