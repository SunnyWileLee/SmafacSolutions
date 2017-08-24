using AutoMapper;
using Smafac.Framework.Core.Models;
using Smafac.Wms.Goods.Applications;
using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Models;
using Smafac.Wms.Goods.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Services
{
    class GoodsPropertyService : IGoodsPropertyService
    {
        private readonly IGoodsPropertyRepository _goodsPropertyRepository;
        private readonly IGoodsPropertyValueRepository _goodsPropertyValueRepository;
        private readonly IGoodsPropertyProvider _goodsPropertyProvider;

        public GoodsPropertyService(IGoodsPropertyRepository goodsPropertyRepository,
                                        IGoodsPropertyValueRepository goodsPropertyValueRepository,
                                        IGoodsPropertyProvider goodsPropertyProvider
                                    )
        {
            _goodsPropertyRepository = goodsPropertyRepository;
            _goodsPropertyValueRepository = goodsPropertyValueRepository;
            _goodsPropertyProvider = goodsPropertyProvider;
        }

        public bool AddProperty(GoodsPropertyModel model)
        {
            var property = Mapper.Map<GoodsPropertyEntity>(model);
            property.SubscriberId = UserContext.Current.SubscriberId;
            return _goodsPropertyRepository.AddProperty(property);
        }

        public bool UpdateProperty(GoodsPropertyModel model)
        {
            return _goodsPropertyRepository.UpdateProperty(model);
        }

        public bool DeleteProperty(Guid propertyId)
        {
            if (_goodsPropertyValueRepository.Any(UserContext.Current.SubscriberId, propertyId))
            {
                return false;
            }
            return _goodsPropertyRepository.DeleteProperty(UserContext.Current.SubscriberId, propertyId);
        }

        public List<GoodsPropertyModel> GetProperties()
        {
            var properties = _goodsPropertyRepository.GetProperties(UserContext.Current.SubscriberId);
            return Mapper.Map<List<GoodsPropertyModel>>(properties);
        }

        public List<GoodsPropertyModel> GetProperties(Guid goodsId)
        {
            return _goodsPropertyProvider.Provide(goodsId);

        }
    }
}
