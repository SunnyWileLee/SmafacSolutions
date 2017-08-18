using AutoMapper;
using Smafac.Framework.Core.Models;
using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Services
{
    class GoodsAutoMapper : SmafacAutoMapper
    {
        public override void CreateMapper(IMapperConfigurationExpression cfg)
        {
            base.BipassMapper<GoodsEntity, GoodsModel>(cfg);
            base.BipassMapper<GoodsPropertyEntity, GoodsPropertyModel>(cfg);
            base.BipassMapper<GoodsPropertyValueEntity, GoodsModel>(cfg);
            base.BipassMapper<GoodsCategoryEntity, GoodsModel>(cfg);
        }
    }
}
