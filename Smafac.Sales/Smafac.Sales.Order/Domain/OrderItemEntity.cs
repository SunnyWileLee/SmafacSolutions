﻿using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Domain
{
    class OrderItemEntity : SaasBaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid GoodsId { get; set; }
        public decimal Quantity { get; set; }
    }
}
