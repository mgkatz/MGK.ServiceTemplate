using MGK.Acceptance;
using MGK.Extensions;
using MGK.ServiceBase.CQRS.Commands;
using MGK.ServiceBase.CQRS.SeedWork;
using MGK.ServiceTemplate.API.Infrastructure.ServiceProviders;
using MGK.ServiceTemplate.API.Models;
using MGK.ServiceTemplate.API.Models.ProofOfConcept;
using MGK.ServiceTemplate.Manager.Infrastructure.Services.ProofOfConcept;
using MGK.ServiceTemplate.Manager.Models.ProofOfConcept;
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

		public async Task<PersonViewModel> Handle(AddPersonCommand request, CancellationToken cancellationToken)
		{
			var addPersonDto = Mapper.Map<AddPersonDto>(request);
			var personDto = await PersonService.AddPersonAsync(addPersonDto);

			return Mapper.Map<PersonViewModel>(personDto);
		}

		public async Task<ResponseViewModel> Handle(RemovePersonCommand request, CancellationToken cancellationToken)
		{
			var personDto = await PersonService.RemovePerson(request.PersonId);

			return new ResponseViewModel
			{
				Message = APIResources.MessagesResources.InformationRemovePersonSuccess.Format(personDto.FullName, personDto.DocumentNumber),
				Data = new RemovedPersonViewModel(personDto.FullName, personDto.DocumentNumber)
			};
		}

		public async Task<PersonViewModel> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
		{
			var personDto = Mapper.Map<PersonDto>(request);
			personDto = await PersonService.UpdatePerson(personDto);
			// Logger.LogInformation("Person information was updated successfully.");
			return Mapper.Map<PersonViewModel>(personDto);
		}
	}
}
