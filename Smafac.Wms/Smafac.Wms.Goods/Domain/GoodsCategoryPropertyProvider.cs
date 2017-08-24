using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Models;
using Smafac.Wms.Goods.Repositories;
using Smafac.Framework.Core.Models;
using AutoMapper;
using Smafac.Wms.Goods.Models;

namespace Smafac.Wms.Goods.Domain
{
    class GoodsCategoryPropertyProvider : IGoodsCategoryPropertyProvider
    {
        private readonly IGoodsCategoryPropertyRepository _goodsCategoryPropertyRepository;
        private readonly IGoodsCategoryRepository _goodsCategoryRepository;

        public GoodsCategoryPropertyProvider(IGoodsCategoryPropertyRepository goodsCategoryPropertyRepository,
                                            IGoodsCategoryRepository goodsCategoryRepository)
        {
            _goodsCategoryPropertyRepository = goodsCategoryPropertyRepository;
            _goodsCategoryRepository = goodsCategoryRepository;
        }

        public List<GoodsPropertyModel> Provide(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
            {
                return new List<GoodsPropertyModel>();
            }
            var subscriberId = UserContext.Current.SubscriberId;
            var category = _goodsCategoryRepository.GetCategory(subscriberId, categoryId);
            if (category == null)
            {
                return new List<GoodsPropertyModel>();
            }
            var properties = _goodsCategoryPropertyRepository.GetProperties(subscriberId, categoryId) ?? new List<GoodsPropertyEntity>();
            if (category.IsRoot())
            {
                return Mapper.Map<List<GoodsPropertyModel>>(properties);
            }
            return Provide(category.ParentId).Union(Mapper.Map<List<GoodsPropertyModel>>(properties)).ToList();
        }
    }
}
