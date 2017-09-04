﻿using Smafac.Sales.Order.Applications;
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
using Smafac.Sales.Order.Applications.Charge;
using Smafac.Sales.Order.Repositories.Charge;

namespace Smafac.Sales.Order.Services.Charge
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
            var subscriberId = UserContext.Current.SubscriberId;
            if (_orderChargeRepository.Any(subscriberId, model.Name))
            {
                return false;
            }
            var charge = Mapper.Map<OrderChargeEntity>(model);
            charge.SubscriberId = subscriberId;
            return _orderChargeRepository.AddCharge(charge);
        }

        public bool DeleteCharge(Guid chargeId)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            if (_orderChargeValueRepository.Any(subscriberId, chargeId))
            {
                return false;
            }
            if (_orderChargeRepository.DeleteCharge(subscriberId, chargeId))
            {
                return _orderChargeValueRepository.Delete(subscriberId, chargeId);
            }
            return true;
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