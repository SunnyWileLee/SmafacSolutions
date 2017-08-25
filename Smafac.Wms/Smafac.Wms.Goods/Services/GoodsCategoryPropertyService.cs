using Smafac.Wms.Goods.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Models;
using Smafac.Wms.Goods.Repositories;
using Smafac.Framework.Core.Models;
using AutoMapper;
using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Models;

namespace Smafac.Wms.Goods.Services
{
    class GoodsCategoryPropertyService : IGoodsCategoryPropertyService
    {
        private readonly IGoodsCategoryPropertyRepository _goodsCategoryPropertyRepository;
        private readonly IGoodsCategoryPropertyProvider _goodsCategoryPropertyProvider;

        public GoodsCategoryPropertyService(IGoodsCategoryPropertyRepository goodsCategoryPropertyRepository,
                                            IGoodsCategoryPropertyProvider goodsCategoryPropertyProvider)
        {
            _goodsCategoryPropertyRepository = goodsCategoryPropertyRepository;
            _goodsCategoryPropertyProvider = goodsCategoryPropertyProvider;
        }

        public bool BindProperties(Guid categoryId, IEnumerable<Guid> propertyIds)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            if (_goodsCategoryPropertyRepository.IsBound(subscriberId, categoryId))
            {
                if (!_goodsCategoryPropertyRepository.UnbindProperties(subscriberId, categoryId))
                {
                    return false;
                }
            }
            return _goodsCategoryPropertyRepository.BindProperties(subscriberId, categoryId, propertyIds);
        }

        public List<GoodsPropertyModel> GetProperties(Guid categoryId)
        {
            var properties = _goodsCategoryPropertyRepository.GetProperties(UserContext.Current.SubscriberId, categoryId);
            return Mapper.Map<List<GoodsPropertyModel>>(properties);
        }

        public List<GoodsPropertyModel> GetPropertiesIncludeParents(Guid categoryId)
        {
            var properties = _goodsCategoryPropertyProvider.Provide(categoryId);
            return properties;
        }
    }
}
