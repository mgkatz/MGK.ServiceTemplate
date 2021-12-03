using MGK.ServiceBase.CQRS.Queries;
using MGK.ServiceTemplate.API.Models.ProofOfConcept;
using System.Collections.Generic;

namespace MGK.ServiceTemplate.API.Application.Queries.ProofOfConcept
{
    public class GetAllPersonsQuery : QueryEnumerableBase<IEnumerable<PersonViewModel>>
    {
    }
}
