using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories
{
    public abstract class EntityAddRepository<TContext, TEntity> : EntityRepository<TContext, TEntity>,
                                                                        IEntityAddRepository<TEntity>
        where TContext : DbContext
        where TEntity : SaasBaseEntity
    {
        protected virtual bool AllowAnonymous
        {
            get
            {
                return false;
            }
        }

        public bool AddEntities(IEnumerable<TEntity> entities)
        {
            if (!AllowAnonymous && entities.Any(entity => entity.IsAnonymous()))
            {
                return false;
            }
            using (var context = ContextProvider.Provide())
            {
                context.Set<TEntity>().AddRange(entities);
                return context.SaveChanges() > 0;
            }
        }

        public virtual bool AddEntity(TEntity entity)
        {
            if (!AllowAnonymous && entity.IsAnonymous())
            {
                return false;
            }
            using (var context = ContextProvider.Provide())
            {
                context.Set<TEntity>().Add(entity);
                return context.SaveChanges() > 0;
            }
        }
    }
}
