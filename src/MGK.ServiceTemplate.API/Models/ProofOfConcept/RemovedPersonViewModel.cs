using MGK.ServiceBase.CQRS.SeedWork;
using MGK.ServiceTemplate.API.Infrastructure.Contracts.ProofOfConcept;

namespace MGK.ServiceTemplate.API.Models.ProofOfConcept
{
	public class RemovedPersonViewModel : IPersonContract, IResponse
	{
		public string Fullname { get; init; }

		public string DocumentNumber { get; init; }
	}
}
