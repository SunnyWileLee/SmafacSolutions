using Smafac.Framework.Core.Repositories;
using Smafac.Wms.Stock.Domain;
using Smafac.Wms.Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Stock.Repositories
{
    interface IStockUpdateRepository : IEntityUpdateRepository<StockEntity>
    {

    }
}
