using Smafac.Wms.Stock.Domain;
using Smafac.Wms.Stock.Models;
using System.Linq;

namespace Smafac.Wms.Stock.Repositories.Joiners
{
    class StockJoiner : IStockJoiner
    {
        public IQueryable<StockModel> Join(IQueryable<StockEntity> stocks, IQueryable<StockCategoryEntity> categories)
        {
            var query = from stock in stocks
                        join category in categories on stock.CategoryId equals category.Id
                        select new StockModel
                        {
                            CategoryId = stock.CategoryId,
                            SubscriberId = stock.SubscriberId,
                            CategoryName = category.Name,
                            CreateTime = stock.CreateTime,
                            Id = stock.Id,
                            GoodsId = stock.GoodsId,
                            Quantity = stock.Quantity,
                            StockDate = stock.StockDate
                        };
            return query;
        }
    }
}
