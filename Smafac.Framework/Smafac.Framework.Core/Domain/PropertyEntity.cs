using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Core.Domain
{
    public abstract class PropertyEntity : CustomizedColumnEntity
    {
        public PropertyType Type { get; set; }

        protected virtual TPropertyValueEntity CreateValueBase<TPropertyValueEntity>(string value) where TPropertyValueEntity : PropertyValueEntity
        {
            var propertyValue = default(TPropertyValueEntity);
            propertyValue.PropertyId = this.Id;
            propertyValue.SubscriberId = this.SubscriberId;
            propertyValue.Value = value;

            return propertyValue;
        }
    }
}
