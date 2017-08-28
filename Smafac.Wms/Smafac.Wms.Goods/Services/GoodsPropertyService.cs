using AutoMapper;
using Smafac.Framework.Core.Models;
using Smafac.Wms.Goods.Applications;
using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Models;
using Smafac.Wms.Goods.Repositories;
using Smafac.Wms.Goods.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Services
{
    class GoodsPropertyService : IGoodsPropertyService
    {
        private readonly IGoodsPropertyAddRepository _goodsPropertyAddRepository;
        private readonly IGoodsPropertyDeleteRepository _goodsPropertyDeleteRepository;
        private readonly IGoodsPropertyUpdateRepository _goodsPropertyUpdateRepository;
        private readonly IGoodsPropertySearchRepository _goodsPropertySearchRepository;
        private readonly IGoodsPropertyValueRepository _goodsPropertyValueRepository;
        private readonly IGoodsPropertyProvider _goodsPropertyProvider;

        public GoodsPropertyService(IGoodsPropertyAddRepository goodsPropertyAddRepository,
                                    IGoodsPropertyDeleteRepository goodsPropertyDeleteRepository,
                                    IGoodsPropertyUpdateRepository goodsPropertyUpdateRepository,
                                    IGoodsPropertySearchRepository goodsPropertySearchRepository,
                                    IGoodsPropertyValueRepository goodsPropertyValueRepository,
                                    IGoodsPropertyProvider goodsPropertyProvider
                                    )
        {
            _goodsPropertyAddRepository = goodsPropertyAddRepository;
            _goodsPropertyDeleteRepository = goodsPropertyDeleteRepository;
            _goodsPropertyUpdateRepository = goodsPropertyUpdateRepository;
            _goodsPropertySearchRepository = goodsPropertySearchRepository;
            _goodsPropertyValueRepository = goodsPropertyValueRepository;
            _goodsPropertyProvider = goodsPropertyProvider;
        }

        public bool AddProperty(GoodsPropertyModel model)
        {
            var property = Mapper.Map<GoodsPropertyEntity>(model);
            property.SubscriberId = UserContext.Current.SubscriberId;
            return _goodsPropertyAddRepository.AddEntity(property);
        }

        public bool UpdateProperty(GoodsPropertyModel model)
        {
            var property = Mapper.Map<GoodsPropertyEntity>(model);
            property.SubscriberId = UserContext.Current.SubscriberId;
            return _goodsPropertyUpdateRepository.UpdateEntity(property);
        }

        public bool DeleteProperty(Guid propertyId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            //if (_goodsPropertyRepository.IsUsed(subscriberId, propertyId))
            //{
            //    return false;
            //}
            if (_goodsPropertyValueRepository.Any(subscriberId, propertyId))
            {
                return false;
            }
            return _goodsPropertyDeleteRepository.DeleteEntity(subscriberId, propertyId);
        }

        public List<GoodsPropertyModel> GetProperties()
        {
            var properties = _goodsPropertySearchRepository.GetEntities(UserContext.Current.SubscriberId, s => true);
            return Mapper.Map<List<GoodsPropertyModel>>(properties);
        }

        public List<GoodsPropertyModel> GetProperties(Guid goodsId)
        {
            return _goodsPropertyProvider.Provide(goodsId);
        }
    }
}
