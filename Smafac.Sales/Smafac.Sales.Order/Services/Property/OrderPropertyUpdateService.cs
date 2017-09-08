using Smafac.Framework.Core.Services.Property;
using Smafac.Sales.Order.Applications.Property;
using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Models;
using Smafac.Sales.Order.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Services.Property
{
    class OrderPropertyUpdateService : PropertyUpdateService<OrderPropertyEntity, OrderPropertyModel>,
                                        IOrderPropertyUpdateService
    {
        public OrderPropertyUpdateService(IOrderPropertySearchRepository OrderPropertySearchRepository,
                                          IOrderPropertyUpdateRepository OrderPropertyUpdateRepository)
        {
            base.CustomizedColumnSearchRepository = OrderPropertySearchRepository;
            base.CustomizedColumnUpdateRepository = OrderPropertyUpdateRepository;
        }
    }
}
