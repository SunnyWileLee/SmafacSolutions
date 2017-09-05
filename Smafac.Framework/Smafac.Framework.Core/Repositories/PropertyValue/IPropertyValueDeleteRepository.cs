using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.PropertyValue
{
    public interface IPropertyValueDeleteRepository<TPropertyValue> : IEntityDeleteRepository<TPropertyValue>
        where TPropertyValue : PropertyValueEntity
    {
        bool DeleteByProperty(Guid subscriberId, Guid propertyId);
    }
}
