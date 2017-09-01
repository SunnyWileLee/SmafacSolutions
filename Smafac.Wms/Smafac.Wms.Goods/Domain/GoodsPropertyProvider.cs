using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Models;
using Smafac.Wms.Goods.Repositories;
using Smafac.Framework.Core.Models;
using Smafac.Wms.Goods.Models;

namespace Smafac.Wms.Goods.Domain
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
