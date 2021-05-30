using MGK.ServiceTemplate.Manager.SeedWork;
using System;

namespace MGK.ServiceTemplate.Manager.Models.ProofOfConcept
{
	public class PersonDto : IManagerResponse
	{
		public Guid PersonId { get; set; }

		public string Name { get; set; }

		public string Surname { get; set; }

		public string FullName => $"{Name} {Surname}";

		public string DocumentNumber { get; set; }

		public DateTime BirthDate { get; set; }

		public DateTime CreationDate { get; set; }

		public DateTime? LastUpdateDate { get; set; }
	}
}
