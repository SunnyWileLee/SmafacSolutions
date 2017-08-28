using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories
{
    public interface IEntityDeleteRepository<TEntity> where TEntity : SaasBaseEntity
    {
        bool DeleteEntity(Guid subscriberId, Guid entityId);
    }
}
