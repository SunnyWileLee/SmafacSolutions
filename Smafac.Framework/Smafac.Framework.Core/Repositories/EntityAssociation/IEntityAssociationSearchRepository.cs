using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.EntityAssociation
{
    public interface IEntityAssociationSearchRepository<TEntity, TAssociation>
        where TEntity : SaasBaseEntity
        where TAssociation : SaasBaseEntity
    {
        bool IsBound(Guid subscriberId, Guid entityId);
        List<TAssociation> GetAssociations(Guid subscriberId, Guid entityId);
        bool Any(Guid subscriberId, Guid associationId);
    }
}
