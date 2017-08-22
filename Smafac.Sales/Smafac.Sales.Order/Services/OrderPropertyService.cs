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

namespace Smafac.Sales.Order.Services
{
    class OrderPropertyService : IOrderPropertyService
    {
        private readonly IOrderPropertyRepository _orderPropertyRepository;
        private readonly IOrderPropertyValueRepository _orderPropertyValueRepository;

        public OrderPropertyService(IOrderPropertyRepository orderPropertyRepository,
                                IOrderPropertyValueRepository orderPropertyValueRepository
                                    )
        {
            _orderPropertyRepository = orderPropertyRepository;
            _orderPropertyValueRepository = orderPropertyValueRepository;
        }

        public bool AddProperty(OrderPropertyModel model)
        {
            if (_orderPropertyRepository.Any(UserContext.Current.SubscriberId, model.Name))
            {
                return false;
            }
            var charge = Mapper.Map<OrderPropertyEntity>(model);
            return _orderPropertyRepository.AddProperty(charge);
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
            if (_orderPropertyRepository.DeleteProperty(subscriberId, chargeId) && isDeleteValues)
            {
                return _orderPropertyValueRepository.Delete(subscriberId, chargeId);
            }
            return true;
        }

        public List<OrderPropertyModel> GetProperties()
        {
            var charges = _orderPropertyRepository.GetProperties(UserContext.Current.SubscriberId);
            return Mapper.Map<List<OrderPropertyModel>>(charges);
        }

        public bool UpdateProperty(OrderPropertyModel model)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var charges = _orderPropertyRepository.GetProperties(subscriberId);
            if (charges.Any(s => s.Name == model.Name && s.Id != model.Id))
            {
                return false;
            }
            return _orderPropertyRepository.UpdateProperty(model);
        }
    }
}
