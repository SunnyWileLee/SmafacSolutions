using Smafac.Framework.Core.Models;
using Smafac.Wms.Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Stock.Domain.Property
{
    interface IStockPropertyProvider
    {
        List<StockPropertyModel> Provide(Guid goodsId);
    }
}
