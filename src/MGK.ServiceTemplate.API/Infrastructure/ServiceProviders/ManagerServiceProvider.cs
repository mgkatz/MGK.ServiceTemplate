using MGK.ServiceBase.Services;
using MGK.ServiceTemplate.Manager.SeedWork;
using System;

namespace MGK.ServiceTemplate.API.Infrastructure.ServiceProviders
{
	public sealed class ManagerServiceProvider : ServiceProvider<string, IManagerService>, IManagerServiceProvider
	{
		public ManagerServiceProvider(Func<string, IManagerService> managerServices)
			: base(managerServices)
		{
		}

		public TOutputService Get<TOutputService>()
			where TOutputService : class, IManagerService
		{
			var key = typeof(TOutputService).Name;
			return Get<TOutputService>(key);
		}
	}
}
