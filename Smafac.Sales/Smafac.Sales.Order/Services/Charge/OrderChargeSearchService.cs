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
        private readonly IOrderChargeSearchRepository _orderChargeSearchRepository;
        private readonly IOrderChargeProvider _orderChargeProvider;

        public OrderChargeSearchService(IOrderChargeSearchRepository orderChargeSearchRepository,
                                        IOrderChargeProvider orderChargeProvide
                                    )
        {
            _orderChargeSearchRepository = orderChargeSearchRepository;
            _orderChargeProvider = orderChargeProvide;
        }

        public List<OrderChargeModel> GetCharges()
        {
            var charges = _orderChargeSearchRepository.GetEntities(UserContext.Current.SubscriberId, s => true);
            return Mapper.Map<List<OrderChargeModel>>(charges);
        }
    }
}
