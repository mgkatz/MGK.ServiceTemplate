using MGK.ServiceBase.CQRS.Commands;
using MGK.ServiceTemplate.API.Models.ProofOfConcept;
using System;

namespace MGK.ServiceTemplate.API.Application.Commands.ProofOfConcept
{
	public class AddPersonCommand : CommandBase<PersonViewModel>
	{
		public string Name { get; set; }

		public string Surname { get; set; }

		public string DocumentNumber { get; set; }

		public DateTime BirthDate { get; set; }
	}
}
