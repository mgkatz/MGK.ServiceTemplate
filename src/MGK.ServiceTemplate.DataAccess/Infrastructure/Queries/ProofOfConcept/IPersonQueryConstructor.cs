using MGK.ServiceBase.DAL.SeedWork;
using MGK.ServiceTemplate.DataAccess.Models.ProofOfConcept;
using MGK.ServiceTemplate.DataAccess.SeedWork;
using System;

namespace MGK.ServiceTemplate.DataAccess.Infrastructure.Queries.ProofOfConcept
{
	public interface IPersonQueryConstructor : IQueryConstructor<Person, IPersonQueryConstructor>, IDataAccessService
	{
		IPersonQueryConstructor FilterByDocumentNumber(string documentNumber);
		IPersonQueryConstructor FilterById(Guid personId);
		IPersonQueryConstructor OrderByFullName();
	}
}
