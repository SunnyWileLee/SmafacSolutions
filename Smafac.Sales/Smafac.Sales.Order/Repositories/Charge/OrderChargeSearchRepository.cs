using Smafac.Framework.Core.Repositories.CustomizedColumn;
using Smafac.Sales.Order.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Repositories.Charge
{
    class OrderChargeSearchRepository : CustomizedColumnSearchRepository<OrderContext, OrderChargeEntity>,
                                        IOrderChargeSearchRepository
    {
        public OrderChargeSearchRepository(IOrderContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
