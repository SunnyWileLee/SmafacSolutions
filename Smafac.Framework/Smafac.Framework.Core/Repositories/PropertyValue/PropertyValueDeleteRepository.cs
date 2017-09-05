using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.PropertyValue
{
    public abstract class PropertyValueDeleteRepository<TContext, TPropertyValue> : EntityDeleteRepository<TContext, TPropertyValue>,
                                            IPropertyValueDeleteRepository<TPropertyValue>
            where TContext : DbContext
            where TPropertyValue : PropertyValueEntity
    {
        public virtual bool DeleteByProperty(Guid subscriberId, Guid propertyId)
        {
            using (var context = ContextProvider.Provide())
            {
                var values = context.Set<TPropertyValue>().Where(s => s.SubscriberId == subscriberId && s.PropertyId == propertyId).ToList();
                if (!values.Any())
                {
                    return true;
                }
                context.Set<TPropertyValue>().RemoveRange(values);
                return context.SaveChanges() > 0;
            }
        }
    }
}
