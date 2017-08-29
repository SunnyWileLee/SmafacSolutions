using Smafac.Sales.Order.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Sales.Order.Models;
using Smafac.Sales.Order.Repositories;
using AutoMapper;
using Smafac.Sales.Order.Domain;
using Smafac.Framework.Core.Models;
using Smafac.Sales.Order.Repositories.Property;

namespace Smafac.Sales.Order.Services
{
    class OrderPropertyService : IOrderPropertyService
    {

        private readonly IOrderPropertyValueRepository _orderPropertyValueRepository;
        private readonly IOrderPropertyAddRepository _orderPropertyAddRepository;
        private readonly IOrderPropertyDeleteRepository _orderPropertyDeleteRepository;
        private readonly IOrderPropertySearchRepository _orderPropertySearchRepository;
        private readonly IOrderPropertyUpdateRepository _orderPropertyUpdateRepository;

        public OrderPropertyService(IOrderPropertyAddRepository orderPropertyAddRepository,
                                    IOrderPropertyDeleteRepository orderPropertyDeleteRepository,
                                    IOrderPropertySearchRepository orderPropertySearchRepository,
                                    IOrderPropertyUpdateRepository orderPropertyUpdateRepository,
                                    IOrderPropertyValueRepository orderPropertyValueRepository
                                    )
        {
            _orderPropertyAddRepository = orderPropertyAddRepository;
            _orderPropertyDeleteRepository = orderPropertyDeleteRepository;
            _orderPropertySearchRepository = orderPropertySearchRepository;
            _orderPropertyUpdateRepository = orderPropertyUpdateRepository;
            _orderPropertyValueRepository = orderPropertyValueRepository;
        }

        public bool AddProperty(OrderPropertyModel model)
        {
            if (_orderPropertySearchRepository.Any(UserContext.Current.SubscriberId, model.Name))
            {
                return false;
            }
            var charge = Mapper.Map<OrderPropertyEntity>(model);
            return _orderPropertyAddRepository.AddEntity(charge);
        }

        public bool DeleteProperty(Guid chargeId, bool isDeleteValues = false)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            if (!isDeleteValues)
            {
                if (_orderPropertyValueRepository.Any(subscriberId, chargeId))
                {
                    return false;
                }
            }
            if (_orderPropertyDeleteRepository.DeleteEntity(subscriberId, chargeId) && isDeleteValues)
            {
                return _orderPropertyValueRepository.Delete(subscriberId, chargeId);
            }
            return true;
        }

        public List<OrderPropertyModel> GetProperties()
        {
            var charges = _orderPropertySearchRepository.GetEntities(UserContext.Current.SubscriberId, s => true);
            return Mapper.Map<List<OrderPropertyModel>>(charges);
        }

        public bool UpdateProperty(OrderPropertyModel model)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var properties = _orderPropertySearchRepository.GetEntities(subscriberId, s => true);
            if (properties.Any(s => s.Name == model.Name && s.Id != model.Id))
            {
                return false;
            }
            var property = Mapper.Map<OrderPropertyEntity>(model);
            property.SubscriberId = subscriberId;
            return _orderPropertyUpdateRepository.UpdateEntity(property);
        }
    }
}
