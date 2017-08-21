using Smafac.Sales.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Presentation.Domain
{
    public interface IOrderWrapper
    {
        void Wrapper(List<OrderModel> orders);
    }
}
