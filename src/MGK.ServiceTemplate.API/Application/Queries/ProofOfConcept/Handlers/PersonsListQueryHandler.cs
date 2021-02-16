using AutoMapper;
using MGK.ServiceBase.CQRS.Queries;
using MGK.ServiceTemplate.API.Models.ProofOfConcept;
using MGK.ServiceTemplate.Manager.Infrastructure.Services.ProofOfConcept;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MGK.ServiceTemplate.API.Application.Queries.ProofOfConcept.Handlers
{
	public class PersonsListQueryHandler :
		IQueryEnumerableHandler<GetAllPersonsQuery, IEnumerable<PersonViewModel>>
	{
		private readonly IMapper _mapper;
		private readonly IPersonService _personService;

		public PersonsListQueryHandler(
			IPersonService personService,
			IMapper mapper)
		{
			_mapper = mapper;
			_personService = personService;
		}

		public async Task<IEnumerable<PersonViewModel>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
		{
			var persons = await _personService.GetAllPersonsAsync();
			return _mapper.Map<PersonViewModel[]>(persons);
		}
	}
}
