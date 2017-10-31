using Smafac.Framework.Core.Repositories;
using Smafac.Pms.Purchase.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Repositories
{
    class PurchaseContext : SmafacContext
    {
        public DbSet<PurchaseEntity> Purchases { get; set; }
        public DbSet<PurchaseCategoryEntity> PurchaseCategories { get; set; }
        public DbSet<PurchaseCategoryPropertyEntity> PurchaseCategoryProperties { get; set; }
        public DbSet<PurchasePropertyEntity> PurchaseProperties { get; set; }
        public DbSet<PurchasePropertyValueEntity> PurchasePropertyValues { get; set; }
    }
}
