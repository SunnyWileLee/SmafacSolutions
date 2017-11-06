using Smafac.Framework.Core.Models;
using Smafac.Wms.Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Stock.Applications
{
    public interface IStockSearchService
    {
        StockModel GetStock(Guid goodsId);
        StockDetailModel GetStockDetail(Guid goodsId);
        PageModel<StockModel> GetStockPage(StockPageQueryModel query);
        List<StockModel> GetStock(StockPageQueryModel query);
        List<StockModel> GetStock(IEnumerable<Guid> goodsIds);
    }
}
