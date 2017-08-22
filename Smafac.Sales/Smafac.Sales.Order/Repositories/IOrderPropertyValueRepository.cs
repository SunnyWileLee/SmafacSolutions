using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Repositories
{
    interface IOrderPropertyValueRepository
    {
        bool AddPropertyValues(Guid orderId, IEnumerable<OrderPropertyValueEntity> values);
        bool UpdatePropertyValue(OrderPropertyValueModel model);
        List<OrderPropertyValueModel> GetPropertyValues(Guid subscriberId, Guid orderId);
        IEnumerable<IGrouping<Guid, OrderPropertyValueModel>> GetPropertyValues(Guid subscriberId, IEnumerable<Guid> orderIds);
        bool Any(Guid subscriberId, Guid propertyId);
        bool Delete(Guid subscriberId, Guid propertyId);
    }
}
