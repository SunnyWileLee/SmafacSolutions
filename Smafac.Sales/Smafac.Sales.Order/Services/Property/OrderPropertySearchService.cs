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
    class OrderPropertySearchService : PropertySearchService<OrderPropertyEntity, OrderPropertyModel>, IOrderPropertySearchService
    {
        private readonly IOrderPropertyProvider _orderPropertyProvider;

        public OrderPropertySearchService(IOrderPropertySearchRepository orderSearchRepository,
                                            IOrderPropertyProvider orderPropertyProvider)
        {
            base.CustomizedColumnSearchRepository = orderSearchRepository;
            _orderPropertyProvider = orderPropertyProvider;
        }

        public override List<OrderPropertyModel> GetColumns(Guid entityId)
        {
            return _orderPropertyProvider.Provide(entityId);
        }
    }
}
