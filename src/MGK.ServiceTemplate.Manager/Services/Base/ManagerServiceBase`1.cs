using MGK.ServiceBase.Services;
using MGK.ServiceTemplate.Manager.SeedWork;

namespace MGK.ServiceTemplate.Manager.Services.Base
{
	public abstract class ManagerServiceBase<T> : ServiceBase<T>
		where T : class, IManagerService
	{
		protected ManagerServiceBase(IManagerInternalServices<T> internalServices)
			: base(internalServices)
		{
		}
	}
}
