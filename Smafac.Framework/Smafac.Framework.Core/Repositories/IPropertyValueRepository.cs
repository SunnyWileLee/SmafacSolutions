using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories
{
    public interface IPropertyValueRepository<TPropertyValue> where TPropertyValue : PropertyValueEntity
    {
        bool SetPropertyValue(TPropertyValue value);
        List<TPropertyValue> GetPropertyValues(Guid SubscriberId, Guid entityId);
        IEnumerable<IGrouping<Guid, TPropertyValue>> GetPropertyValues(Guid SubscriberId, IEnumerable<Guid> entityIds);
        bool Any(Guid SubscriberId, Guid propertyId);
        bool AddPropertyValues(Guid subscriberId, Guid entityId, IEnumerable<TPropertyValue> values);
    }
}
