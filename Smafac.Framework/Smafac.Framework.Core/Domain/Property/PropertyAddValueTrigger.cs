using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories;
using Smafac.Framework.Core.Repositories.PropertyValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain.Property
{
    public abstract class PropertyAddValueTrigger<TProperty, TPropertyValue, TEntity> : IPropertyAddTrigger<TProperty>
        where TProperty : PropertyEntity
        where TPropertyValue : PropertyValueEntity
        where TEntity : SaasBaseEntity
    {

        public virtual IPropertyValueSetRepository<TPropertyValue> PropertyValueSetRepository
        {
            get; protected set;
        }

        public virtual IEntitySearchRepository<TEntity> EntitySearchRepository
        {
            get; protected set;
        }

        public virtual bool Added(TProperty property)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var ids = EntitySearchRepository.GetIds(subscriberId, s => true).ToList();
            var values = ids.Select(id => CreatePropertyValue(id, property));
            return PropertyValueSetRepository.AddEntities(values);
        }

        protected virtual TPropertyValue CreatePropertyValue(Guid entityId, TProperty property)
        {
            var value = CreatePropertyValue();
            ModifyValue(value, entityId, property);
            return value;
        }

        protected virtual TPropertyValue CreatePropertyValue()
        {
            return Activator.CreateInstance<TPropertyValue>();
        }

        protected virtual void ModifyValue(TPropertyValue value, Guid entityId, TProperty property)
        {
            value.PropertyId = property.Id;
            value.SubscriberId = UserContext.Current.SubscriberId;
            value.Value = string.Empty;
        }
    }
}
