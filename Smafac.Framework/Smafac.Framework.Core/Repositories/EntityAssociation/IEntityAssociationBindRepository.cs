using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.EntityAssociation
{
    public interface IEntityAssociationBindRepository<TCategory, TAssociation>
        where TCategory : SaasBaseEntity
        where TAssociation : SaasBaseEntity
    {
        bool BindEntity(Guid subscriberId, Guid entityId, IEnumerable<Guid> associationIds);
        bool UnbindEntity(Guid subscriberId, Guid entityId);
        bool UnbindAssociation(Guid subscriberId, Guid associationId);
    }
}
