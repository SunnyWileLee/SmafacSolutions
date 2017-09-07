using Smafac.Framework.Core.Domain.EntityAssociationProviders;
using Smafac.Sales.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Domain.CategoryCharge
{
    interface IOrderCategoryChargeProvider : IEntityAssociationProvider<OrderChargeModel>
    {
    }
}
