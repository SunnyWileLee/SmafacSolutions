using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Sales.Order.Models;

namespace Smafac.Sales.Order.Domain
{
    class OrderCategoryPropertyProvider : CategoryPropertyProvider<OrderPropertyEntity>, IOrderCategoryPropertyProvider
    {
        public OrderCategoryPropertyProvider()
        {

        }

        public List<OrderPropertyModel> Provide(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        protected override CategoryEntity GetCategory(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<OrderPropertyEntity> GetProperties(Guid categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
