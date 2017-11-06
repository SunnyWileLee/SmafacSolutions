using Smafac.Wms.Stock.Models;
using System.Collections.Generic;

namespace Smafac.Presentation.Domain.Purchase
{
    public interface IStockWrapper
    {
        void Wrapper(List<StockModel> stocks);
    }
}
