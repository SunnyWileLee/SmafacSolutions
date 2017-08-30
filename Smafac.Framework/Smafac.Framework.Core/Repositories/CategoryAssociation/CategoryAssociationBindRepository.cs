using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.EntityAssociation
{
    public abstract class EntityAssociationBindRepository<TContext, TEntity, TAssociation, TEntityAssociation> : IEntityAssociationBindRepository<TEntity, TAssociation>
        where TContext : DbContext
        where TEntity : SaasBaseEntity
        where TAssociation : SaasBaseEntity
        where TEntityAssociation : SaasBaseEntity
    {
        public virtual IDbContextProvider<TContext> ContextProvider { get; protected set; }

        public virtual bool BindAssociations(Guid subscriberId, Guid entityId, IEnumerable<Guid> associationIds)
        {
            using (var context = ContextProvider.Provide())
            {
                if (!context.Set<TEntity>().Any(s => s.SubscriberId == subscriberId && s.Id == entityId))
                {
                    return false;
                }
                var allPropertyIds = context.Set<TAssociation>().Where(s => s.SubscriberId == subscriberId).Select(s => s.Id).ToList();
                if (associationIds.Any(p => !allPropertyIds.Contains(p)))
                {
                    return false;
                }
                var binds = this.CreateBinds(subscriberId, entityId, associationIds);
                context.Set<TEntityAssociation>().AddRange(binds);
                return context.SaveChanges() > 0;
            }
        }

        protected abstract IEnumerable<TEntityAssociation> CreateBinds(Guid subscriberId, Guid categoryId, IEnumerable<Guid> propertyIds);

        public virtual bool UnbindAssociations(Guid subscriberId, Guid entityId)
        {
            using (var context = ContextProvider.Provide())
            {
                var binds = this.GetBinds(context.Set<TEntityAssociation>().Where(s => s.SubscriberId == subscriberId), entityId);
                context.Set<TEntityAssociation>().RemoveRange(binds);
                return context.SaveChanges() > 0;
            }
        }

        protected abstract IEnumerable<TEntityAssociation> GetBinds(IQueryable<TEntityAssociation> binds, Guid entityId);
    }
}
