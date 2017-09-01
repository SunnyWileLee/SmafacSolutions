using Smafac.Sales.Order.Applications.Charge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Sales.Order.Models;
using AutoMapper;
using Smafac.Sales.Order.Repositories.Charge;
using Smafac.Framework.Core.Models;
using Smafac.Sales.Order.Domain.Charge;

namespace Smafac.Sales.Order.Services.Charge
{
    class OrderChargeSearchService : IOrderChargeSearchService
    {
        private readonly IOrderChargeRepository _orderChargeRepository;
        private readonly IOrderChargeProvider _orderChargeProvider;

        public OrderChargeSearchService(IOrderChargeRepository orderChargeRepository,
                                        IOrderChargeProvider orderChargeProvide
                                    )
        {
            _orderChargeRepository = orderChargeRepository;
            _orderChargeProvider = orderChargeProvide;
        }

        public List<OrderChargeModel> GetCharges()
        {
            var charges = _orderChargeRepository.GetCharges(UserContext.Current.SubscriberId);
            return Mapper.Map<List<OrderChargeModel>>(charges);
        }

        public List<OrderChargeModel> GetCharges(Guid orderId)
        {
            throw new NotImplementedException();
        }
    }
}
