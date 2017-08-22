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

namespace Smafac.Wms.Goods.Services
{
    class GoodsSearchService : IGoodsSearchService
    {
        private readonly IGoodsSearchRepository _goodsSearchRepository;

        public GoodsSearchService(IGoodsSearchRepository goodsSearchRepository)
        {
            _goodsSearchRepository = goodsSearchRepository;
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

        public PageModel<GoodsModel> GetGoodsPage(GoodsPageQueryModel model)
        {
            var predicate = model.CreatePredicate<GoodsEntity>();
            var goods = _goodsSearchRepository.GetGoodsPage(UserContext.Current.SubscriberId, predicate, model.Skip, model.PageSize);
            var count = _goodsSearchRepository.GetGoodsCount(UserContext.Current.SubscriberId, predicate);
            return new PageModel<GoodsModel> { PageSize = model.PageSize, PageData = goods, PageIndex = model.PageIndex, TotalCount = count };
        }
    }
}
