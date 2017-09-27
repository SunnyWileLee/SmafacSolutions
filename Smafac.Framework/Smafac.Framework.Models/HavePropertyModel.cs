using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Models
{
    public abstract class HavePropertyModel : SaasBaseModel
    {
        public virtual IEnumerable<PropertyValueModel> PropertyValues { get; }

        public bool HasProperties
        {
            get
            {
                return PropertyValues != null && PropertyValues.Any();
            }
        }

        public virtual string GetPropertyValue(Guid propertyId)
        {
            var value = PropertyValues.FirstOrDefault(s => s.PropertyId == propertyId);
            return value == null ? string.Empty : value.Value;
        }
    }
}
