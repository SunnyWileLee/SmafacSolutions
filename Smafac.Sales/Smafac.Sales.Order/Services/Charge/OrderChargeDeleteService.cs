using Smafac.Framework.Core.Services.CustomizedColumn;
using Smafac.Sales.Order.Applications.Charge;
using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Domain.Charge;
using Smafac.Sales.Order.Models;
using Smafac.Sales.Order.Repositories.Charge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Services.Charge
{
    class OrderChargeDeleteService : CustomizedColumnDeleteService<OrderChargeEntity, OrderChargeModel>, IOrderChargeDeleteService
    {
        public OrderChargeDeleteService(IOrderChargeDeleteRepository orderChargeDeleteRepository,
                                          IOrderChargeSearchRepository orderChargeSearchRepository,
                                          IEnumerable<IOrderChargeUsedChecker> orderChargeUsedCheckers,
                                          IOrderChargeDeleteTrigger[] orderChargeDeleteTriggers)
        {
            base.CustomizedColumnDeleteRepository = orderChargeDeleteRepository;
            base.CustomizedColumnUsedCheckers = orderChargeUsedCheckers;
            base.CustomizedColumnSearchRepository = orderChargeSearchRepository;
            base.CustomizedColumnDeleteTriggers = orderChargeDeleteTriggers;
        }
    }
}
