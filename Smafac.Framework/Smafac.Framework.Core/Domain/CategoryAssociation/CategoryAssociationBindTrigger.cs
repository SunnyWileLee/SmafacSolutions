using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain.CategoryAssociation
{
    public abstract class CategoryAssociationBindTrigger<TEntity, TCategory, TAssociation, TAssociationValue> : ICategoryAssociationBindTrigger<TCategory, TAssociation>
            where TCategory : CategoryEntity
            where TAssociation : SaasBaseEntity
            where TEntity : SaasBaseEntity
            where TAssociationValue : SaasBaseEntity
    {
        public virtual IEntitySearchRepository<TEntity> EntitySearchRepository
        {
            get; protected set;
        }

        public virtual IEntityAddRepository<TAssociationValue> AssociationValueAddRepository
        {
            get; protected set;
        }

        public virtual bool Bound(TCategory category, TAssociation association)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var entityIds = EntitySearchRepository.GetIds(subscriberId, CreateEntityPredicate(category));
            var values = entityIds.Select(id => this.CreateValue(id, association));
            return AssociationValueAddRepository.AddEntities(values);
        }

        protected virtual TAssociationValue CreateValue(Guid entityId, TAssociation association)
        {
            var value = CreateValue();
            ModifyValue(value, entityId, association);
            return value;
        }

        protected virtual TAssociationValue CreateValue()
        {
            return Activator.CreateInstance<TAssociationValue>();
        }

        protected virtual void ModifyValue(TAssociationValue value, Guid entityId, TAssociation association)
        {
            value.SubscriberId = UserContext.Current.SubscriberId;
        }

        protected abstract Expression<Func<TEntity, bool>> CreateEntityPredicate(TCategory category);
    }
}
