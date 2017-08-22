using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Domain
{
    [Table("OrderProperty")]
    class OrderPropertyEntity : PropertyEntity
    {
        public OrderPropertyValueEntity CreateEmptyValue()
        {
            return this.CreateValue(Guid.Empty, string.Empty);
        }

        public OrderPropertyValueEntity CreateValue(Guid orderId, string value)
        {
            return new OrderPropertyValueEntity
            {
                OrderId = orderId,
                Value = value,
                PropertyId = this.Id,
                SubscriberId = this.SubscriberId
            };
        }
    }
}
