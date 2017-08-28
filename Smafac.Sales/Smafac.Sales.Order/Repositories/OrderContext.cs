using Smafac.Framework.Core.Repositories;
using Smafac.Sales.Order.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Repositories
{
    class OrderContext : SmafacContext
    {
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderChargeEntity> OrderCharges { get; set; }
        public DbSet<OrderChargeValueEntity> OrderChargeValues { get; set; }
        public DbSet<OrderCategoryEntity> OrderCategories { get; set; }
        public DbSet<OrderCategoryPropertyEntity> OrderCategoryProperties { get; set; }
        public DbSet<OrderPropertyEntity> OrderProperties { get; set; }
        public DbSet<OrderPropertyValueEntity> OrderPropertyValues { get; set; }
        public DbSet<OrderStatusEntity> OrderStatuses { get; set; }
        public DbSet<OrderStatusChangedEntity> OrderStatusChangeds { get; set; }
    }
}
