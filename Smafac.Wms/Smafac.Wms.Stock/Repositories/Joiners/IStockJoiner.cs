using Smafac.Wms.Stock.Domain;
using Smafac.Wms.Stock.Models;
using System.Linq;

namespace Smafac.Wms.Stock.Repositories.Joiners
{
    interface IStockJoiner
    {
        IQueryable<StockModel> Join(IQueryable<StockEntity> goodses, IQueryable<StockCategoryEntity> categories);
    }
}
