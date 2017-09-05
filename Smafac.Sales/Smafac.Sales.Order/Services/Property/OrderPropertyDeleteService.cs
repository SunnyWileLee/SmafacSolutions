using Smafac.Framework.Core.Services.Property;
using Smafac.Sales.Order.Applications.Property;
using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Domain.Property;
using Smafac.Sales.Order.Models;
using Smafac.Sales.Order.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Services.Property
{
    class OrderPropertyDeleteService : PropertyDeleteService<OrderPropertyEntity, OrderPropertyModel>, IOrderPropertyDeleteService
    {
        public OrderPropertyDeleteService(IOrderPropertyDeleteRepository orderPropertyDeleteRepository,
                                           IOrderPropertySearchRepository orderPropertySearchRepository,
                                           IEnumerable<IOrderPropertyUsedChecker> orderPropertyUsedCheckers,
                                            IOrderPropertyDeleteTrigger[] orderPropertyDeleteTriggers)
        {
            base.PropertyDeleteRepository = orderPropertyDeleteRepository;
            base.PropertyUsedCheckers = orderPropertyUsedCheckers;
            base.PropertySearchRepository = orderPropertySearchRepository;
            base.PropertyDeleteTriggers = orderPropertyDeleteTriggers;
        }
    }
}
