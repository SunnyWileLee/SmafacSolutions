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
    class OrderChargeService : IOrderChargeService
    {
        private readonly IOrderChargeRepository _orderChargeRepository;
        private readonly IOrderChargeValueRepository _orderChargeValueRepository;

        public OrderChargeService(IOrderChargeRepository orderChargeRepository,
                                IOrderChargeValueRepository orderChargeValueRepository
                                    )
        {
            _orderChargeRepository = orderChargeRepository;
            _orderChargeValueRepository = orderChargeValueRepository;
        }

        public bool AddCharge(OrderChargeModel model)
        {
            if (_orderChargeRepository.Any(UserContext.Current.SubscriberId, model.Name))
            {
                return false;
            }
            var charge = Mapper.Map<OrderChargeEntity>(model);
            return _orderChargeRepository.AddCharge(charge);
        }

        public bool DeleteCharge(Guid chargeId, bool isDeleteValues = false)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            if (!isDeleteValues)
            {
                if (_orderChargeValueRepository.Any(subscriberId, chargeId))
                {
                    return false;
                }
            }
            if (_orderChargeRepository.DeleteCharge(subscriberId, chargeId) && isDeleteValues)
            {
                return _orderChargeValueRepository.Delete(subscriberId, chargeId);
            }
            return true;
        }

        public List<OrderChargeModel> GetCharges()
        {
            var charges = _orderChargeRepository.GetCharges(UserContext.Current.SubscriberId);
            return Mapper.Map<List<OrderChargeModel>>(charges);
        }

        public bool UpdateCharge(OrderChargeModel model)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var charges = _orderChargeRepository.GetCharges(subscriberId);
            if (charges.Any(s => s.Name == model.Name && s.Id != model.Id))
            {
                return false;
            }
            return _orderChargeRepository.UpdateCharge(model);
        }
    }
}
