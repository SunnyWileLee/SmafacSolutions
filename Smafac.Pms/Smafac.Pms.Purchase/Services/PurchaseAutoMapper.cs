using AutoMapper;
using Smafac.Framework.Core.Models;
using Smafac.Pms.Purchase.Domain;
using Smafac.Pms.Purchase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Services
{
    class PurchaseAutoMapper : SmafacAutoMapper
    {
        public override void CreateMapper(IMapperConfigurationExpression cfg)
        {
            base.BipassMapper<PurchaseEntity, PurchaseModel>(cfg);
            base.BipassMapper<PurchasePropertyEntity, PurchasePropertyModel>(cfg);
            base.BipassMapper<PurchasePropertyValueEntity, PurchasePropertyValueModel>(cfg);
            base.BipassMapper<PurchaseCategoryEntity, PurchaseCategoryModel>(cfg);
        }
    }
}
