using AutoMapper;
using MGK.ServiceBase.DAL.Infrastructure.Queries;
using MGK.ServiceBase.DAL.SeedWork;
using MGK.ServiceTemplate.DataAccess.Contexts;

namespace MGK.ServiceTemplate.DataAccess.Infrastructure.Queries.ProofOfConcept
{
	public abstract class ProofOfConceptQueryConstructor<TEntity, TQueryConstructor> :
		QueryConstructor<ProofOfConceptContext, TEntity, TQueryConstructor>
		where TEntity : class, IDataUnit
		where TQueryConstructor : class, IQueryConstructor
	{
		protected ProofOfConceptQueryConstructor(ProofOfConceptContext context, IMapper mapper)
			: base(context, mapper)
		{
		}
	}
}
