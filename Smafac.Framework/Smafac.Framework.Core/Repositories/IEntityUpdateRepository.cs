using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories
{
    public interface IEntityUpdateRepository<TEntity> where TEntity : SaasBaseEntity
    {
        bool UpdateEntity(TEntity entity);
    }
}
