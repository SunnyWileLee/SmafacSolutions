using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Domain.CustomizedColumn;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Domain
{
    [Table("OrderCharge")]
    class OrderChargeEntity : CustomizedColumnEntity
    {
        public OrderChargeValueEntity CreateEmptyValue()
        {
            return this.CreateValue(Guid.Empty, 0);
        }


        public OrderChargeValueEntity CreateValue(Guid orderId, decimal charge)
        {
            return new OrderChargeValueEntity
            {
                Charge = charge,
                SubscriberId = this.SubscriberId,
                ChargeId = this.Id,
                CreateTime = DateTime.Now,
                OrderId = orderId
            };
        }
    }
}
