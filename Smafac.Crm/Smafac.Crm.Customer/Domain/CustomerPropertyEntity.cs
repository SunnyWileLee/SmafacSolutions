using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Domain
{
    [Table("CustomerProperty")]
    class CustomerPropertyEntity : PropertyEntity
    {
        public CustomerPropertyValueEntity SetValue(Guid customerId, string value)
        {
            return new CustomerPropertyValueEntity
            {
                SubscriberId = this.SubscriberId,
                CustomerId = customerId,
                PropertyId = this.Id,
                Value = value
            };
        }
    }
}
