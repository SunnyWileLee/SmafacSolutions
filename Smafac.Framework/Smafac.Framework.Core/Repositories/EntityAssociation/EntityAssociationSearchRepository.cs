using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.EntityAssociation
{
    public abstract class EntityAssociationSearchRepository<TContext, TEntity, TAssociation, TEntityAssociation> : IEntityAssociationSearchRepository<TEntity, TAssociation>
        where TContext : DbContext
        where TEntity : SaasBaseEntity
        where TAssociation : SaasBaseEntity
        where TEntityAssociation : SaasBaseEntity
    {
        public virtual IDbContextProvider<TContext> ContextProvider { get; protected set; }

        public virtual List<TAssociation> GetAssociations(Guid subscriberId, Guid entityId)
        {
            using (var context = ContextProvider.Provide())
            {
                var propertyIds = GetAssociationIds(context.Set<TEntityAssociation>().Where(s => s.SubscriberId == subscriberId), entityId);
                var properties = context.Set<TAssociation>()
                                        .Where(s => s.SubscriberId == subscriberId && propertyIds.Contains(s.Id))
                                        .ToList();
                return properties;
            }
        }

        protected abstract IEnumerable<Guid> GetAssociationIds(IQueryable<TEntityAssociation> binds, Guid entityId);

        public virtual bool IsBound(Guid subscriberId, Guid entityId)
        {
            using (var context = ContextProvider.Provide())
            {
                return IsBound(context.Set<TEntityAssociation>().Where(s => s.SubscriberId == subscriberId), entityId);
            }
        }

        protected abstract bool IsBound(IQueryable<TEntityAssociation> binds, Guid entityId);

        public abstract bool Any(Guid subscriberId, Guid associationId);
    }
}
