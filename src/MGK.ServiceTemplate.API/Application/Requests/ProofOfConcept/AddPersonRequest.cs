using MediatR;
using System;

namespace MGK.ServiceTemplate.API.Application.Requests.ProofOfConcept
{
	public class AddPersonRequest : IRequest
	{
		public string Name { get; set; }

		public string Surname { get; set; }

		public string DocumentNumber { get; set; }

		public DateTime BirthDate { get; set; }

		public AddPersonRequest()
		{
		}
	}
}
