using Smafac.Framework.Core.Models;
using Smafac.Framework.Models;
using Smafac.Wms.Goods.Applications;
using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Models;
using Smafac.Wms.Goods.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using Smafac.Framework.Core.Repositories.Query;
using Smafac.Wms.Goods.Repositories.PropertyValue;
using Smafac.Wms.Goods.Repositories.Property;
using Smafac.Wms.Goods.Domain.Pages;

namespace Smafac.Wms.Goods.Services
{
    class GoodsSearchService : IGoodsSearchService
    {
        private readonly IGoodsSearchRepository _goodsSearchRepository;
        private readonly IGoodsPropertyValueSearchRepository _goodsPropertyValueSearchRepository;
        private readonly IGoodsPageQueryer _goodsPageQueryer;

        public GoodsSearchService(IGoodsSearchRepository goodsSearchRepository,
                                    IGoodsPropertyValueSearchRepository goodsPropertyValueSearchRepository,
                                    IGoodsPageQueryer goodsPageQueryer
                                    )
        {
            _goodsSearchRepository = goodsSearchRepository;
            _goodsPropertyValueSearchRepository = goodsPropertyValueSearchRepository;
            _goodsPageQueryer = goodsPageQueryer;
        }

        public List<GoodsModel> GetGoods(string key)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            Expression<Func<GoodsEntity, bool>> predicate = s => s.Name.Contains(key);
            return _goodsSearchRepository.GetGoods(subscriberId, predicate);
        }

        public List<GoodsModel> GetGoods(IEnumerable<Guid> goodsIds)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            Expression<Func<GoodsEntity, bool>> predicate = s => goodsIds.Contains(s.Id);
            return _goodsSearchRepository.GetGoods(subscriberId, predicate);
        }

        public GoodsModel GetGoods(Guid goodsId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var goods = _goodsSearchRepository.GetGoods(subscriberId, goodsId);
            var properties = _goodsPropertyValueSearchRepository.GetPropertyValues(subscriberId, goodsId);
            goods.Properties = properties;
            return goods;
        }

        public GoodsDetailModel GetGoodsDetail(Guid goodsId)
        {
            var goods = this.GetGoods(goodsId);
            return new GoodsDetailModel { Goods = goods };
        }


        public PageModel<GoodsModel> GetGoodsPage(GoodsPageQueryModel query)
        {
            return _goodsPageQueryer.Query(query);
        }
    }
}
