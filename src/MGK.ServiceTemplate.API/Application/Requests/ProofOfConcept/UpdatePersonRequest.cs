using MediatR;

namespace MGK.ServiceTemplate.API.Application.Requests.ProofOfConcept
{
	public class UpdatePersonRequest : IRequest
	{
		public string Name { get; set; }

		public string Surname { get; set; }
	}
}
