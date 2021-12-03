using AutoMapper;
using MGK.Acceptance;
using MGK.ServiceBase.Services;
using MGK.ServiceTemplate.Manager.Infrastructure.ServiceProviders;
using MGK.ServiceTemplate.Manager.SeedWork;
using Microsoft.Extensions.Logging;

namespace MGK.ServiceTemplate.Manager.Services.Base
{
	internal class ManagerInternalServices<T> : InternalServices<T>, IManagerInternalServices<T>
		where T : class, IManagerService
	{
		public ManagerInternalServices(
			IDataAccessServiceProvider dataAccessServiceProvider,
			IMapper mapper,
			ILogger<T> logger)
			: base(mapper, logger)
		{
			Ensure.Parameter.IsNotNull(dataAccessServiceProvider, nameof(dataAccessServiceProvider));

			DataAccessServiceProvider = dataAccessServiceProvider;
		}

		public IDataAccessServiceProvider DataAccessServiceProvider { get; }
	}
}
