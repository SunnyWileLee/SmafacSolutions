﻿using Smafac.Framework.Core.Models;
using Smafac.Wms.Goods.Domain.CategoryProperty;
using Smafac.Wms.Goods.Models;
using Smafac.Wms.Goods.Repositories;
using System;
using System.Collections.Generic;

namespace Smafac.Wms.Goods.Domain.Property
{
    class GoodsPropertyProvider : IGoodsPropertyProvider
    {
        private readonly IGoodsSearchRepository _goodsSearchRepository;
        private readonly IGoodsCategoryPropertyProvider _goodsCategoryPropertyProvider;

        public GoodsPropertyProvider(IGoodsSearchRepository goodsSearchRepository,
                                    IGoodsCategoryPropertyProvider goodsCategoryPropertyProvider
                                    )
        {
            _goodsSearchRepository = goodsSearchRepository;
            _goodsCategoryPropertyProvider = goodsCategoryPropertyProvider;
        }

        public List<GoodsPropertyModel> Provide(Guid goodsId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var goods = _goodsSearchRepository.GetGoods(subscriberId, goodsId);
            return _goodsCategoryPropertyProvider.ProvideAssociations(goods.CategoryId);
        }
    }
}
