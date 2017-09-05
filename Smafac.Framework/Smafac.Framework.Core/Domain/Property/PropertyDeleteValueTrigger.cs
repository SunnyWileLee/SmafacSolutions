using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.PropertyValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain.Property
{
    public abstract class PropertyDeleteValueTrigger<TProperty, TPropertyValue> : IPropertyDeleteTrigger<TProperty>
            where TProperty : PropertyEntity
            where TPropertyValue : PropertyValueEntity
    {
        public virtual IPropertyValueDeleteRepository<TPropertyValue> PropertyValueDeleteRepository
        {
            get;
            protected set;
        }

        public virtual bool Deleted(TProperty entity)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            if (subscriberId != entity.SubscriberId)
            {
                return false;
            }
            return PropertyValueDeleteRepository.DeleteByProperty(subscriberId, entity.Id);
        }
    }
}
