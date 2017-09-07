using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories
{
    public interface IEntityAddRepository<TEntity> : IEntityRepository<TEntity>
        where TEntity : SaasBaseEntity
    {
        bool AddEntity(TEntity entity);
        bool AddEntities(IEnumerable<TEntity> entities);
    }
}
