using MGK.Acceptance;
using MGK.Extensions;
using MGK.ServiceBase.CQRS.Commands;
using MGK.ServiceBase.CQRS.SeedWork;
using MGK.ServiceTemplate.API.Infrastructure.ServiceProviders;
using MGK.ServiceTemplate.API.Models;
using MGK.ServiceTemplate.API.Models.ProofOfConcept;
using MGK.ServiceTemplate.Manager.Infrastructure.Services.ProofOfConcept;
using MGK.ServiceTemplate.Manager.Models.ProofOfConcept;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace MGK.ServiceTemplate.API.Application.Commands.ProofOfConcept.Handlers
{
	public class PersonCommandHandler : CommandHandler<PersonCommandHandler>,
		IHandlerService,
		ICommandHandler<AddPersonCommand, PersonViewModel>,
		ICommandHandler<RemovePersonCommand, ResponseViewModel>,
		ICommandHandler<UpdatePersonCommand, PersonViewModel>
	{
		private readonly IManagerServiceProvider _managerServiceProvider;

		public PersonCommandHandler(
			IManagerServiceProvider managerServiceProvider,
			ICqrsInternalServices<PersonCommandHandler> internalServices)
			: base(internalServices)
		{
			Ensure.Parameter.IsNotNull(managerServiceProvider, nameof(managerServiceProvider));

			_managerServiceProvider = managerServiceProvider;
		}

		private IPersonService PersonService
			=> _managerServiceProvider.Get<IPersonService>();

		public async Task<PersonViewModel> Handle(AddPersonCommand request, CancellationToken cancellationToken = default)
		{
			var addPersonDto = Mapper.Map<AddPersonDto>(request);
			var personDto = await PersonService.AddPersonAsync(addPersonDto, cancellationToken);
			Logger.LogInformation($"A new person with id '{personDto.PersonId}' was added successfully.");

			return Mapper.Map<PersonViewModel>(personDto);
		}

		public async Task<ResponseViewModel> Handle(RemovePersonCommand request, CancellationToken cancellationToken = default)
		{
			var personDto = await PersonService.RemovePerson(request.PersonId, cancellationToken);
			Logger.LogInformation($"The information of the person with id '{request.PersonId}' was removed successfully.");

			return new ResponseViewModel
			{
				Message = APIResources.MessagesResources.InformationRemovePersonSuccess.Format(personDto.FullName, personDto.DocumentNumber),
				Data = new RemovedPersonViewModel { Fullname = personDto.FullName, DocumentNumber = personDto.DocumentNumber }
			};
		}

		public async Task<PersonViewModel> Handle(UpdatePersonCommand request, CancellationToken cancellationToken = default)
		{
			var personDto = Mapper.Map<PersonDto>(request);
			personDto = await PersonService.UpdatePerson(personDto, cancellationToken);
			Logger.LogInformation($"The information of the person with id '{request.PersonId}' was updated successfully.");
			return Mapper.Map<PersonViewModel>(personDto);
		}
	}
}
