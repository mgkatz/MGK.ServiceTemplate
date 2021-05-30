using MGK.ServiceBase.Services.SeedWork;
using MGK.ServiceTemplate.Manager.SeedWork;

namespace MGK.ServiceTemplate.API.Infrastructure.ServiceProviders
{
	public interface IManagerServiceProvider : IServiceProvider<string, IManagerService>
	{
		TOutputService Get<TOutputService>()
			where TOutputService : class, IManagerService;
	}
}
