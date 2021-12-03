using MGK.ServiceBase.Services.SeedWork;
using MGK.ServiceTemplate.Manager.Infrastructure.ServiceProviders;

namespace MGK.ServiceTemplate.Manager.SeedWork
{
	public interface IManagerInternalServices<T> : IInternalServices<T>
		where T : IManagerService
	{
		IDataAccessServiceProvider DataAccessServiceProvider { get; }
	}
}
