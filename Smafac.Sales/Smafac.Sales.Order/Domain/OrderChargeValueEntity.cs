using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Domain
{
    class OrderChargeValueEntity : SaasBaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid ChargeId { get; set; }
        public decimal Charge { get; set; }
    }
}
