using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Sales.Order.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Repositories.CategoryProperty
{
    interface IOrderCategoryPropertyBindRepository : ICategoryPropertyBindRepository<OrderCategoryEntity, OrderPropertyEntity>
    {
    }
}
