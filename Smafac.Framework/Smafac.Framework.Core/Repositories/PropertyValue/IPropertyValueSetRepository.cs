using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Repositories.PropertyValue
{
    public interface IPropertyValueSetRepository<TPropertyValue> where TPropertyValue : PropertyValueEntity
    {
        bool SetPropertyValue(TPropertyValue model);
        bool AddPropertyValues(Guid entityId, IEnumerable<TPropertyValue> values);
        bool AddPropertyValues(IEnumerable<TPropertyValue> values);
    }
}
