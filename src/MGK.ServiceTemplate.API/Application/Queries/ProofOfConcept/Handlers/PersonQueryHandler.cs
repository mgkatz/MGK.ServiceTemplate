using MGK.Acceptance;
using MGK.Extensions;
using MGK.ServiceBase.CQRS.Queries;
using MGK.ServiceBase.CQRS.SeedWork;
using MGK.ServiceBase.IWEManager.Infrastructure.Exceptions;
using MGK.ServiceTemplate.API.Infrastructure.ServiceProviders;
using MGK.ServiceTemplate.API.Models.ProofOfConcept;
using MGK.ServiceTemplate.Manager.Infrastructure.Services.ProofOfConcept;
using System.Threading;
using System.Threading.Tasks;

namespace MGK.ServiceTemplate.API.Application.Queries.ProofOfConcept.Handlers
{
	public class PersonQueryHandler : QueryHandler<PersonQueryHandler>,
		IHandlerService,
		IQueryHandler<GetPersonQuery, PersonViewModel>
	{
		private readonly IManagerServiceProvider _managerServiceProvider;

		public PersonQueryHandler(
			IManagerServiceProvider managerServiceProvider,
			ICqrsInternalServices<PersonQueryHandler> internalServices)
			: base(internalServices)
		{
			Ensure.Parameter.IsNotNull(managerServiceProvider, nameof(managerServiceProvider));

			_managerServiceProvider = managerServiceProvider;
		}

		private IPersonService PersonService
			=> _managerServiceProvider.Get<IPersonService>();

		public async Task<PersonViewModel> Handle(GetPersonQuery request, CancellationToken cancellationToken)
		{
			var personDto = await PersonService.GetPersonByIdAsync(request.PersonId);

			if (personDto == null)
			{
				Raise.Error.Generic<NotFoundException>(
					APIResources.MessagesResources.ErrorPersonNotExists,
					APIResources.MessagesResources.ErrorPersonNotExistsDetails.Format(request.PersonId));
			}

			return Mapper.Map<PersonViewModel>(personDto);
		}
	}
}
