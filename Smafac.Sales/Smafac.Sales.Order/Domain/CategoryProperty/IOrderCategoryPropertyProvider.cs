using Smafac.Framework.Core.Domain;
using Smafac.Sales.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Domain.CategoryProperty
{
    interface IOrderCategoryPropertyProvider : ICategoryPropertyProvider<OrderPropertyEntity, OrderPropertyModel>
    {

    }
}
