using MGK.ServiceBase.DAL.Infrastructure.UnitOfWork;
using MGK.ServiceTemplate.DataAccess.Contexts;
using MGK.ServiceTemplate.DataAccess.Infrastructure.UnitOfWork;

namespace MGK.ServiceTemplate.DataAccess.UnitOfWork
{
    public class ProofOfConceptUoW : UnitOfWork<ProofOfConceptContext>, IProofOfConceptUoW
    {
        public ProofOfConceptUoW(ProofOfConceptContext context)
            : base(context)
        {
        }
    }
}
