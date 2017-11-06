using Smafac.Framework.Core.Repositories.Pages;
using Smafac.Wms.Stock.Domain;
using Smafac.Wms.Stock.Models;

namespace Smafac.Wms.Stock.Repositories.Pages
{
    interface IStockPageQueryRepository : IPageQueryRepository<StockEntity, StockModel>
    {

    }
}
