using Smafac.Framework.Core.Applications.CategoryProperty;
using Smafac.Sales.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Applications.CategoryCharge
{
    public interface IOrderCategoryChargeSearchService : ICategoryPropertySearchService<OrderPropertyModel>
    {
    }
}
