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
using Smafac.Framework.Core.Domain;

namespace Smafac.Wms.Goods.Domain
{
    class GoodsCategoryPropertyProvider : CategoryPropertyProvider<GoodsPropertyEntity>, IGoodsCategoryPropertyProvider
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
            var properties = base.ProvideProperties(categoryId);
            return Mapper.Map<List<GoodsPropertyModel>>(properties);
        }

        protected override CategoryEntity GetCategory(Guid categoryId)
        {
            return _goodsCategoryRepository.GetCategory(UserContext.Current.SubscriberId, categoryId);
        }

        protected override IEnumerable<GoodsPropertyEntity> GetProperties(Guid categoryId)
        {
            return _goodsCategoryPropertyRepository.GetProperties(UserContext.Current.SubscriberId, categoryId) ?? new List<GoodsPropertyEntity>();
        }
    }
}
