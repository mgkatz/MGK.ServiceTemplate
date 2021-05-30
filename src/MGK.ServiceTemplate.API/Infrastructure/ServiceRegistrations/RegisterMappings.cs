using AutoMapper;
using MGK.ServiceBase.Registering.Service;
using MGK.ServiceTemplate.Manager.Infrastructure.Helpers;

namespace MGK.ServiceTemplate.API.Infrastructure.ServiceRegistrations
{
	public class RegisterMappings : RegisterMappingsBase
	{
		protected override IMapper CreateMapper()
		{
			return new MapperConfiguration(config =>
			{
				config.AddMaps(typeof(MappingProfile).Assembly);
				config.AddMaps(ManagerMappingsHelper.GetMappingsAssemblies());
			})
			.CreateMapper();
		}
	}
}
