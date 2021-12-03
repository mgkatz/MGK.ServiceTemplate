using MGK.ServiceBase.CQRS.SeedWork;

namespace MGK.ServiceTemplate.API.Models
{
	public class ResponseViewModel : IResponse, IContract
	{
		public string Message { get; init; }

		public object Data { get; init; }
	}
}
