using MGK.Acceptance;
using MGK.ServiceBase.CQRS.Queries;
using MGK.ServiceBase.CQRS.SeedWork;
using MGK.ServiceTemplate.API.Infrastructure.ServiceProviders;
using MGK.ServiceTemplate.API.Models.ProofOfConcept;
using MGK.ServiceTemplate.Manager.Infrastructure.Services.ProofOfConcept;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MGK.ServiceTemplate.API.Application.Queries.ProofOfConcept.Handlers
{
	public class PersonsListQueryHandler : QueryHandler<PersonsListQueryHandler>,
		IHandlerService,
		IQueryEnumerableHandler<GetAllPersonsQuery, IEnumerable<PersonViewModel>>
	{
		private readonly IManagerServiceProvider _managerServiceProvider;

		public PersonsListQueryHandler(
			IManagerServiceProvider managerServiceProvider,
			ICqrsInternalServices<PersonsListQueryHandler> internalServices)
			: base(internalServices)
		{
			Ensure.Parameter.IsNotNull(managerServiceProvider, nameof(managerServiceProvider));

			_managerServiceProvider = managerServiceProvider;
		}

		private IPersonService PersonService
			=> _managerServiceProvider.Get<IPersonService>();

		public async Task<IEnumerable<PersonViewModel>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
		{
			var persons = await PersonService.GetAllPersonsAsync();
			return Mapper.Map<PersonViewModel[]>(persons);
		}
	}
}
