using Smafac.Framework.Core.Repositories.CategoryAssociation;
using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Sales.Order.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Repositories.CategoryCharge
{
    interface IOrderCategoryChargeSearchRepository : ICategoryAssociationSearchRepository<OrderCategoryEntity, OrderChargeEntity>
    {
    }
}
