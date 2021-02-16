using AutoMapper;
using MGK.Extensions;
using MGK.ServiceBase.CQRS.Commands;
using MGK.ServiceTemplate.API.Models;
using MGK.ServiceTemplate.API.Models.ProofOfConcept;
using MGK.ServiceTemplate.Manager.Infrastructure.Services.ProofOfConcept;
using MGK.ServiceTemplate.Manager.Models.ProofOfConcept;
using System.Threading;
using System.Threading.Tasks;

namespace MGK.ServiceTemplate.API.Application.Commands.ProofOfConcept.Handlers
{
	public class PersonCommandHandler :
		ICommandHandler<AddPersonCommand, PersonViewModel>,
		ICommandHandler<RemovePersonCommand, ResponseViewModel>,
		ICommandHandler<UpdatePersonCommand, PersonViewModel>
	{
		private readonly IPersonService _personService;
		private readonly IMapper _mapper;

		public PersonCommandHandler(
			IPersonService personService,
			IMapper mapper)
		{
			_personService = personService;
			_mapper = mapper;
		}

		public async Task<PersonViewModel> Handle(AddPersonCommand request, CancellationToken cancellationToken)
		{
			var addPersonDto = _mapper.Map<AddPersonDto>(request);
			var personDto = await _personService.AddPersonAsync(addPersonDto);

			return _mapper.Map<PersonViewModel>(personDto);
		}

		public async Task<ResponseViewModel> Handle(RemovePersonCommand request, CancellationToken cancellationToken)
		{
			var personDto = await _personService.RemovePerson(request.PersonId);

			return new ResponseViewModel
			{
				Message = APIResources.MessagesResources.InformationRemovePersonSuccess.Format(personDto.FullName, personDto.DocumentNumber),
				Data = new RemovedPersonViewModel(personDto.FullName, personDto.DocumentNumber)
			};
		}

		public async Task<PersonViewModel> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
		{
			var personDto = _mapper.Map<PersonDto>(request);
			personDto = await _personService.UpdatePerson(personDto);

			return _mapper.Map<PersonViewModel>(personDto);
		}
	}
}
