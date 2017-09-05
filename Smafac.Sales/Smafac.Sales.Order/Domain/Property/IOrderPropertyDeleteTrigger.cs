using Smafac.Framework.Core.Domain.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Domain.Property
{
    interface IOrderPropertyDeleteTrigger : IPropertyDeleteTrigger<OrderPropertyEntity>
    {
    }
}
