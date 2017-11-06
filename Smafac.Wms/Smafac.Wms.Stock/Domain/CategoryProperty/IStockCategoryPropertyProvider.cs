using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Domain.EntityAssociationProviders;
using Smafac.Framework.Core.Models;
using Smafac.Wms.Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Stock.Domain.CategoryProperty
{
    interface IStockCategoryPropertyProvider:IEntityAssociationProvider<StockPropertyModel>
    {
        
    }
}
