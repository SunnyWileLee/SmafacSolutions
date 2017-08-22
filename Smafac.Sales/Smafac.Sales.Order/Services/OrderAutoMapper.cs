using AutoMapper;
using Smafac.Framework.Core.Models;
using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Services
{
    class OrderAutoMapper : SmafacAutoMapper
    {
        public override void CreateMapper(IMapperConfigurationExpression cfg)
        {
            base.BipassMapper<OrderEntity, OrderModel>(cfg);
            base.BipassMapper<OrderPropertyEntity, OrderPropertyModel>(cfg);
            base.BipassMapper<OrderPropertyValueEntity, OrderPropertyValueModel>(cfg);
            base.BipassMapper<OrderChargeEntity, OrderChargeModel>(cfg);
            base.BipassMapper<OrderChargeValueEntity, OrderChargeValueModel>(cfg);
        }
    }
}
