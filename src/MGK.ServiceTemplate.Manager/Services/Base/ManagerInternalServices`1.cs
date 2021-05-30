using AutoMapper;
using MGK.ServiceBase.Services;
using MGK.ServiceTemplate.Manager.SeedWork;
using Microsoft.Extensions.Logging;

namespace MGK.ServiceTemplate.Manager.Services.Base
{
	internal class ManagerInternalServices<T> : InternalServices<T>, IManagerInternalServices<T>
		where T : class, IManagerService
	{
		public ManagerInternalServices(
			IMapper mapper,
			ILogger<T> logger)
			: base(mapper, logger)
		{
		}
	}
}
