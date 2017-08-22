using Smafac.Sales.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Applications
{
    public interface IOrderPropertyService
    {
        bool AddProperty(OrderPropertyModel model);
        List<OrderPropertyModel> GetProperties();
        bool DeleteProperty(Guid chargeId, bool isDeleteValues);
        bool UpdateProperty(OrderPropertyModel model);
    }
}
