using MGK.ServiceBase.DAL.SeedWork;
using MGK.ServiceTemplate.DataAccess.Models.ProofOfConcept;
using System;

namespace MGK.ServiceTemplate.DataAccess.Infrastructure.Queries.ProofOfConcept
{
	public interface IPersonQueryBuilder : IQueryBuilder<Person, IPersonQueryBuilder>
	{
		IPersonQueryBuilder FilterByDocumentNumber(string documentNumber);
		IPersonQueryBuilder FilterById(Guid personId);
		IPersonQueryBuilder OrderByFullName();
	}
}
