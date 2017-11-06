using Smafac.Framework.Core.Repositories;
using Smafac.Wms.Stock.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Stock.Repositories
{
    class StockContext : SmafacContext
    {
        public DbSet<StockEntity> Stocks { get; set; }
        public DbSet<StockCategoryEntity> StockCategories { get; set; }
        public DbSet<StockCategoryPropertyEntity> StockCategoryProperties { get; set; }
        public DbSet<StockPropertyEntity> StockProperties { get; set; }
        public DbSet<StockPropertyValueEntity> StockPropertyValues { get; set; }
    }
}
