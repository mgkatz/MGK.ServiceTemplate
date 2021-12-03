using MGK.ServiceBase.CQRS.Queries;
using MGK.ServiceTemplate.API.Models.ProofOfConcept;
using System;

namespace MGK.ServiceTemplate.API.Application.Queries.ProofOfConcept
{
	public class GetPersonQuery : QueryBase<PersonViewModel>
    {
        public Guid PersonId { get; init; }
    }
}
