using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories
{
    public abstract class EntityUpdateRepository<TContext, TEntity> : EntityRepository<TContext, TEntity>,
                                                                        IEntityUpdateRepository<TEntity>
        where TContext : DbContext
        where TEntity : SaasBaseEntity
    {
        public virtual bool UpdateEntity(TEntity entity)
        {
            using (var context = ContextProvider.Provide())
            {
                var entities = context.Set<TEntity>();
                var instance = entities.FirstOrDefault(s => s.SubscriberId == entity.SubscriberId && s.Id == entity.Id);
                if (instance == null)
                {
                    return false;
                }
                SetValue(instance, entity);
                return context.SaveChanges() > 0;
            }
        }

        protected abstract void SetValue(TEntity entity, TEntity source);
    }
}
