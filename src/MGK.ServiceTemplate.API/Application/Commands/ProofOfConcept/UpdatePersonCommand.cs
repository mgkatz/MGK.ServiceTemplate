using MGK.ServiceBase.CQRS.Commands;
using MGK.ServiceTemplate.API.Models.ProofOfConcept;
using System;

namespace MGK.ServiceTemplate.API.Application.Commands.ProofOfConcept
{
	public class UpdatePersonCommand : CommandBase<PersonViewModel>
	{
		public Guid PersonId { get; set; }

		public string Name { get; set; }

		public string Surname { get; set; }

		public UpdatePersonCommand()
		{
		}
	}
}
