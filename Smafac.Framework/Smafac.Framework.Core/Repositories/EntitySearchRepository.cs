using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories
{
    public abstract class EntitySearchRepository<TContext, TEntity> : EntityRepository<TContext, TEntity>,
                                                                        IEntitySearchRepository<TEntity>
        where TContext : DbContext
        where TEntity : SaasBaseEntity
    {
        public virtual List<TEntity> GetEntities(Guid subscriberId, Expression<Func<TEntity, bool>> predicate)
        {
            using (var context = ContextProvider.Provide())
            {
                var properties = context.Set<TEntity>();
                return properties.Where(s => s.SubscriberId == subscriberId).ToList();
            }
        }
    }
}
