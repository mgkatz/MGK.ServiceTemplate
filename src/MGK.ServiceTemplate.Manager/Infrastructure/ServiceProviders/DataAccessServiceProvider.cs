using MGK.ServiceBase.Services;
using MGK.ServiceTemplate.DataAccess.SeedWork;
using System;

namespace MGK.ServiceTemplate.Manager.Infrastructure.ServiceProviders
{
	public sealed class DataAccessServiceProvider : ServiceProvider<string, IDataAccessService>, IDataAccessServiceProvider
	{
		public DataAccessServiceProvider(Func<string, IDataAccessService> dataAccessServices)
			: base(dataAccessServices)
		{
		}

		public TOutputService Get<TOutputService>()
			where TOutputService : class, IDataAccessService
		{
			var key = typeof(TOutputService).Name;
			return Get<TOutputService>(key);
		}
	}
}
