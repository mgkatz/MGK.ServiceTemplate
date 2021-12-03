using MGK.Acceptance;
using MGK.ServiceBase.Services;
using MGK.ServiceTemplate.Manager.Infrastructure.ServiceProviders;
using MGK.ServiceTemplate.Manager.SeedWork;

namespace MGK.ServiceTemplate.Manager.Services.Base
{
	public abstract class ManagerServiceBase<T> : ServiceHandler<T>
		where T : class, IManagerService
	{
		protected ManagerServiceBase(IManagerInternalServices<T> internalServices)
			: base(internalServices)
		{
			Ensure.Parameter.IsNotNull(internalServices, nameof(internalServices));

			DataAccessServiceProvider = internalServices.DataAccessServiceProvider;
		}

		public IDataAccessServiceProvider DataAccessServiceProvider { get; }
	}
}
