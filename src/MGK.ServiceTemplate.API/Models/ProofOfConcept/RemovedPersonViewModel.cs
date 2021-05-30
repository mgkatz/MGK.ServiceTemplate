using MGK.ServiceBase.CQRS.SeedWork;
using MGK.ServiceTemplate.API.Infrastructure.Contracts.ProofOfConcept;

namespace MGK.ServiceTemplate.API.Models.ProofOfConcept
{
	public class RemovedPersonViewModel : IPersonContract, IResponse
	{
		public string Fullname { get; }

		public string DocumentNumber { get; }

		public RemovedPersonViewModel(string fullName, string documentNumber)
		{
			Fullname = fullName;
			DocumentNumber = documentNumber;
		}
	}
}
