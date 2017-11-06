using AutoMapper;
using Smafac.Framework.Core.Models;
using Smafac.Wms.Stock.Domain;
using Smafac.Wms.Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Stock.Services
{
    class StockAutoMapper : SmafacAutoMapper
    {
        public override void CreateMapper(IMapperConfigurationExpression cfg)
        {
            base.BipassMapper<StockEntity, StockModel>(cfg);
            base.BipassMapper<StockPropertyEntity, StockPropertyModel>(cfg);
            base.BipassMapper<StockPropertyValueEntity, StockPropertyValueModel>(cfg);
            base.BipassMapper<StockCategoryEntity, StockCategoryModel>(cfg);
        }
    }
}
