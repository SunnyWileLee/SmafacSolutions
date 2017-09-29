using Smafac.Framework.Core.Models;
using Smafac.Sales.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Domain.Property
{
    interface IOrderPropertyProvider
    {
        List<OrderPropertyModel> Provide(Guid OrderId);
    }
}
