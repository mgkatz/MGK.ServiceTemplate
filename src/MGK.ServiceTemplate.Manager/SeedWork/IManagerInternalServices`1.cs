using MGK.ServiceBase.Services.SeedWork;

namespace MGK.ServiceTemplate.Manager.SeedWork
{
	public interface IManagerInternalServices<T> : IInternalServices<T>
		where T : IManagerService
	{
	}
}
