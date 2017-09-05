using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories
{
    public abstract class EntityDeleteRepository<TContext, TEntity> : EntityRepository<TContext, TEntity>,
                                                                        IEntityDeleteRepository<TEntity>
        where TContext : DbContext
        where TEntity : SaasBaseEntity
    {
        public virtual bool DeleteEntity(Guid subscriberId, Guid entityId)
        {
            using (var context = ContextProvider.Provide())
            {
                var entities = context.Set<TEntity>();
                var entity = entities.FirstOrDefault(s => s.SubscriberId == subscriberId && s.Id == entityId);
                if (entity == null)
                {
                    return true;
                }
                if (CheckDeleteable(entity))
                {
                    return false;
                }
                entities.Remove(entity);
                return context.SaveChanges() > 0;
            }
        }

        protected virtual bool CheckDeleteable(TEntity entity)
        {
            return true;
        }
    }
}
