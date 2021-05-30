using MGK.ServiceBase.Services.SeedWork;
using MGK.ServiceTemplate.DataAccess.SeedWork;

namespace MGK.ServiceTemplate.Manager.Infrastructure.ServiceProviders
{
	public interface IDataAccessServiceProvider : IServiceProvider<string, IDataAccessService>
	{
		TOutputService Get<TOutputService>()
			where TOutputService : class, IDataAccessService;
	}
}
