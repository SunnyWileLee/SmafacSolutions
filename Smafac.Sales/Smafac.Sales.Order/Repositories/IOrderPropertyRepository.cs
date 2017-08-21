using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Repositories
{
    interface IOrderPropertyRepository
    {
        bool AddProperty(OrderPropertyEntity property);
        List<OrderPropertyEntity> GetProperties(Guid subscriberId);
        bool UpdateProperty(OrderPropertyModel model);
        bool DeleteProperty(Guid subscriberId, Guid propertyId);
    }
}
