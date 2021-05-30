using System.Reflection;

namespace MGK.ServiceTemplate.Manager.Infrastructure.Helpers
{
	public static class ManagerMappingsHelper
	{
		public static Assembly[] GetMappingsAssemblies()
		{
			return new Assembly[]
			{
				typeof(MappingProfile).Assembly,
				typeof(DataAccess.Infrastructure.MappingProfile).Assembly
			};
		}
	}
}
