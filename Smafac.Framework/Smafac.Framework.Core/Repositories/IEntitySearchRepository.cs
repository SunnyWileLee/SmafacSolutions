using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories
{
    public interface IEntitySearchRepository<TEntity> where TEntity : SaasBaseEntity
    {
        List<TEntity> GetEntities(Guid subscriberId, Expression<Func<TEntity, bool>> predicate);
        IEnumerable<Guid> GetIds(Guid subscriberId, Expression<Func<TEntity, bool>> predicate);
        TEntity GetEntity(Guid subscriberId, Guid id);
    }
}
