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
using Smafac.Sales.Order.Applications.Charge;
using Smafac.Sales.Order.Repositories.Charge;
using Smafac.Sales.Order.Repositories.ChargeValue;

namespace Smafac.Sales.Order.Services.Charge
{
    class OrderChargeService : IOrderChargeService
    {
        private readonly IOrderChargeRepository _orderChargeRepository;
        private readonly IOrderChargeSearchRepository _orderChargeSearchRepository;

        public OrderChargeService(IOrderChargeRepository orderChargeRepository,
                                  IOrderChargeSearchRepository orderChargeSearchRepository,
                                  IOrderChargeDeleteService orderChargeDeleteService
                                    )
        {
            _orderChargeRepository = orderChargeRepository;
            _orderChargeSearchRepository = orderChargeSearchRepository;
            DeleteService = orderChargeDeleteService;
        }

        public IOrderChargeDeleteService DeleteService { get; set; }

        public bool AddCharge(OrderChargeModel model)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            if (_orderChargeSearchRepository.Any(subscriberId, model.Name))
            {
                return false;
            }
            var charge = Mapper.Map<OrderChargeEntity>(model);
            charge.SubscriberId = subscriberId;
            return _orderChargeRepository.AddCharge(charge);
        }

        public bool UpdateCharge(OrderChargeModel model)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var charges = _orderChargeSearchRepository.GetEntities(subscriberId, s => true);
            if (charges.Any(s => s.Name == model.Name && s.Id != model.Id))
            {
                return false;
            }
            return _orderChargeRepository.UpdateCharge(model);
        }
    }
}
