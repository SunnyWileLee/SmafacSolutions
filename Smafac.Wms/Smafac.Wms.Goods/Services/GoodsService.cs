using Smafac.Wms.Goods.Applications;
using Smafac.Wms.Goods.Models;
using Smafac.Wms.Goods.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Smafac.Wms.Goods.Domain;
using Smafac.Framework.Core.Models;

namespace Smafac.Wms.Goods.Services
{
    class GoodsService : IGoodsService
    {
        private readonly IGoodsRepository _goodsRepository;
        private readonly IGoodsPropertyValueRepository _goodsPropertyValueRepository;

        public GoodsService(IGoodsRepository goodsRepository,
                            IGoodsPropertyValueRepository goodsPropertyValueRepository
                            )
        {
            _goodsRepository = goodsRepository;
            _goodsPropertyValueRepository = goodsPropertyValueRepository;
        }


        public bool AddGoods(GoodsModel model)
        {
            var goods = Mapper.Map<GoodsEntity>(model);
            goods.SubscriberId = UserContext.Current.SubscriberId;
            var addGoods = _goodsRepository.AddGoods(goods);

            if (addGoods && model.HasProperties)
            {
                model.Properties.ForEach(property =>
                {
                    property.GoodsId = goods.Id;
                    property.SubscriberId = goods.SubscriberId;
                });
                var values = Mapper.Map<List<GoodsPropertyValueEntity>>(model.Properties);
                return _goodsPropertyValueRepository.AddPropertyValues(goods.SubscriberId, goods.Id, values);
            }
            return addGoods;
        }

        public GoodsModel CreateEmptyGoods()
        {
            return new GoodsModel();
        }
    }
}
