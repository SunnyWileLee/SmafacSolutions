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

        public GoodsService(IGoodsRepository goodsRepository)
        {
            _goodsRepository = goodsRepository;
        }


        public bool AddGoods(GoodsModel model)
        {
            var goods = Mapper.Map<GoodsEntity>(model);
            model.SubscriberId = UserContext.Current.SubscriberId;
            return _goodsRepository.AddGoods(goods);
        }

        public GoodsModel CreateEmptyGoods()
        {
            return new GoodsModel();
        }
    }
}
