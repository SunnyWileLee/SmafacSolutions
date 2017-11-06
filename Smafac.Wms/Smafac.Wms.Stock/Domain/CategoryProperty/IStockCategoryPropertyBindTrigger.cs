using Smafac.Framework.Core.Domain.CategoryProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Stock.Domain.CategoryProperty
{
    interface IStockCategoryPropertyBindTrigger: ICategoryPropertyBindTrigger<StockCategoryEntity, StockPropertyEntity>
    {
    }
}
