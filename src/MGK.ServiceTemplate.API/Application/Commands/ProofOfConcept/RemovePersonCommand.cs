using MGK.ServiceBase.CQRS.Commands;
using MGK.ServiceTemplate.API.Models;
using System;

namespace MGK.ServiceTemplate.API.Application.Commands.ProofOfConcept
{
	public class RemovePersonCommand : CommandBase<ResponseViewModel>
	{
		public Guid PersonId { get; init; }
	}
}
