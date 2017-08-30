using Smafac.Framework.Core.Applications.Category;
using Smafac.Sales.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Applications.Category
{
    public interface IOrderCategoryUpdateService : ICategoryUpdateService<OrderCategoryModel>
    {
    }
}
