using MGK.ServiceBase.DAL.Infrastructure.UnitOfWork;
using MGK.ServiceTemplate.DataAccess.Contexts;
using MGK.ServiceTemplate.DataAccess.Infrastructure.UnitOfWork;
using Microsoft.Extensions.Logging;

namespace MGK.ServiceTemplate.DataAccess.UnitOfWork
{
    public class ProofOfConceptUoW : UnitOfWork<ProofOfConceptContext>, IProofOfConceptUoW
    {
        public ProofOfConceptUoW(
            ProofOfConceptContext context,
            ILogger<ProofOfConceptContext> logger)
            : base(context, logger)
        {
        }
    }
}
