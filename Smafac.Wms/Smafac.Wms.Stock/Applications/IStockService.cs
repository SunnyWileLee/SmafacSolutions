using Smafac.Wms.Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Stock.Applications
{
    public interface IStockService
    {
        IStockUpdateService UpdateService { get; set; }
        bool AddStock(StockModel model);
        StockModel CreateEmptyStock();
    }
}
