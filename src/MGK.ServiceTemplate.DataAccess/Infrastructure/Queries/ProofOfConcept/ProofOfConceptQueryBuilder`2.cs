using AutoMapper;
using MGK.ServiceBase.DAL.Infrastructure.Queries;
using MGK.ServiceBase.DAL.SeedWork;
using MGK.ServiceTemplate.DataAccess.Contexts;

namespace MGK.ServiceTemplate.DataAccess.Infrastructure.Queries.ProofOfConcept
{
	public abstract class ProofOfConceptQueryBuilder<TEntity, TQueryBuilder> : QueryBuilder<ProofOfConceptContext, TEntity, TQueryBuilder>
		where TEntity : class, IDataUnit
		where TQueryBuilder : class, IQueryBuilder
	{
		protected ProofOfConceptQueryBuilder(ProofOfConceptContext context, IMapper mapper)
			: base(context, mapper)
		{
		}
	}
}
