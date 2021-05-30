using MGK.ServiceTemplate.Manager.SeedWork;
using System;

namespace MGK.ServiceTemplate.Manager.Models.ProofOfConcept
{
	public class AddPersonDto : IManagerContract
	{
		public string Name { get; set; }

		public string Surname { get; set; }

		public string DocumentNumber { get; set; }

		public DateTime BirthDate { get; set; }
	}
}
