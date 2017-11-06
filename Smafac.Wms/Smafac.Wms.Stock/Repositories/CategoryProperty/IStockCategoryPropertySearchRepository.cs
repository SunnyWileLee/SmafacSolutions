using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Wms.Stock.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Stock.Repositories.CategoryProperty
{
    interface IStockCategoryPropertySearchRepository : ICategoryPropertySearchRepository<StockCategoryEntity, StockPropertyEntity>
    {
    }
}
