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
using Smafac.Wms.Goods.Repositories.PropertyValue;

namespace Smafac.Wms.Goods.Services
{
    class GoodsService : IGoodsService
    {
        private readonly IGoodsAddRepository _goodsRepository;
        private readonly IGoodsPropertyValueSetRepository _goodsPropertyValueSetRepository;

        public GoodsService(IGoodsAddRepository goodsRepository,
                            IGoodsUpdateService updateService,
                            IGoodsPropertyValueSetRepository goodsPropertyValueSetRepository
                            )
        {
            _goodsRepository = goodsRepository;
            _goodsPropertyValueSetRepository = goodsPropertyValueSetRepository;
            UpdateService = updateService;
        }

        public IGoodsUpdateService UpdateService { get; set; }

        public bool AddGoods(GoodsModel model)
        {
            var goods = Mapper.Map<GoodsEntity>(model);
            goods.SubscriberId = UserContext.Current.SubscriberId;
            var add = _goodsRepository.AddEntity(goods);

            if (add && model.HasProperties)
            {
                model.Properties.ForEach(property =>
                {
                    property.GoodsId = goods.Id;
                    property.SubscriberId = goods.SubscriberId;
                });
                var values = Mapper.Map<List<GoodsPropertyValueEntity>>(model.Properties);
                return _goodsPropertyValueSetRepository.AddPropertyValues(goods.Id, values);
            }
            return add;
        }

        public GoodsModel CreateEmptyGoods()
        {
            return new GoodsModel();
        }
    }
}
