﻿using Smafac.Framework.Core.Repositories;
using Smafac.Wms.Goods.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Repositories
{
    class GoodsContext : SmafacContext
    {
        public DbSet<GoodsEntity> Goods { get; set; }
        public DbSet<GoodsCategoryEntity> GoodsCategories { get; set; }
        public DbSet<GoodsCategoryPropertyEntity> GoodsCategoryProperties { get; set; }
        public DbSet<GoodsPropertyEntity> GoodsProperties { get; set; }
        public DbSet<GoodsPropertyValueEntity> GoodsPropertyValues { get; set; }
    }
}
