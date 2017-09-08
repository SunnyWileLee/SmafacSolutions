using Smafac.Wms.Goods.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Wms.Goods.Models;
using Smafac.Wms.Goods.Repositories;
using AutoMapper;
using Smafac.Wms.Goods.Domain;
using Smafac.Framework.Core.Models;
using Smafac.Wms.Goods.Repositories.PropertyValue;

namespace Smafac.Wms.Goods.Services
{
    class GoodsUpdateService : IGoodsUpdateService
    {
        private readonly IGoodsUpdateRepository _goodsUpdateRepository;
        private readonly IGoodsPropertyValueSetRepository _goodsPropertyValueSetRepository;

        public GoodsUpdateService(IGoodsUpdateRepository goodsUpdateRepository,
                                    IGoodsPropertyValueSetRepository goodsPropertyValueSetRepository)
        {
            _goodsUpdateRepository = goodsUpdateRepository;
            _goodsPropertyValueSetRepository = goodsPropertyValueSetRepository;
        }

        public bool UpdateGoods(GoodsModel model)
        {
            var goods = Mapper.Map<GoodsEntity>(model);
            goods.SubscriberId = UserContext.Current.SubscriberId;
            var update = _goodsUpdateRepository.UpdateEntity(goods);

            if (update && model.HasProperties)
            {
                model.Properties.ForEach(property =>
                {
                    property.GoodsId = goods.Id;
                    property.SubscriberId = goods.SubscriberId;
                    var value = Mapper.Map<GoodsPropertyValueEntity>(property);
                    update &= _goodsPropertyValueSetRepository.SetPropertyValue(value);
                });
            }
            return update;
        }
    }
}
