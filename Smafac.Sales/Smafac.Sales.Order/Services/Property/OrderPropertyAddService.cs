using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Core.Services.Property;
using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Models;
using Smafac.Sales.Order.Applications.Property;
using Smafac.Sales.Order.Repositories.Property;

namespace Smafac.Sales.Order.Services.Property
{
    class OrderPropertyAddService : PropertyAddService<OrderPropertyEntity, OrderPropertyModel>, IOrderPropertyAddService
    {
        public OrderPropertyAddService(IOrderPropertyAddRepository OrderPropertyAddRepository,
                                        IOrderPropertySearchRepository OrderPropertySearchRepository)
        {
            base.CustomizedColumnAddRepository = OrderPropertyAddRepository;
            base.CustomizedColumnSearchRepository = OrderPropertySearchRepository;
        }
    }
}
