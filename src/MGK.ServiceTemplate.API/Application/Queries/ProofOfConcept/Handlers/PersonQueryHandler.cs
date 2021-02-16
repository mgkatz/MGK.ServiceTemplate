using AutoMapper;
using MGK.Acceptance;
using MGK.Extensions;
using MGK.ServiceBase.CQRS.Queries;
using MGK.ServiceBase.Infrastructure.Exceptions;
using MGK.ServiceTemplate.API.Models.ProofOfConcept;
using MGK.ServiceTemplate.Manager.Infrastructure.Services.ProofOfConcept;
using System.Threading;
using System.Threading.Tasks;

namespace MGK.ServiceTemplate.API.Application.Queries.ProofOfConcept.Handlers
{
	public class PersonQueryHandler :
		IQueryHandler<GetPersonQuery, PersonViewModel>
	{
		private readonly IMapper _mapper;
		private readonly IPersonService _personService;

		public PersonQueryHandler(
			IPersonService personService,
			IMapper mapper)
		{
			_mapper = mapper;
			_personService = personService;
		}

		public async Task<PersonViewModel> Handle(GetPersonQuery request, CancellationToken cancellationToken)
		{
			var personDto = await _personService.GetPersonByIdAsync(request.PersonId);

			if (personDto == null)
			{
				Raise.Error.Generic<NotFoundException>(
					APIResources.MessagesResources.ErrorPersonNotExists,
					APIResources.MessagesResources.ErrorPersonNotExistsDetails.Format(request.PersonId));
			}

			return _mapper.Map<PersonViewModel>(personDto);
		}
	}
}
