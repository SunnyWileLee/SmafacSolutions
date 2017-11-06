using Smafac.Framework.Core.Domain.Pages;
using Smafac.Wms.Stock.Models;

namespace Smafac.Wms.Stock.Domain.Pages
{
    interface IStockPageQueryer : IPageQueryer<StockModel, StockPageQueryModel>
    {
    }
}
