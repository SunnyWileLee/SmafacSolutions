﻿using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Stock.Domain
{
    [Table("Stock")]
    class StockEntity : SaasBaseEntity
    {
        public StockEntity()
        {
            StockDate = DateTime.Now;
        }
        public Guid GoodsId { get; set; }
        public DateTime StockDate { get; set; } 
        public decimal Quantity { get; set; }
        public Guid CategoryId { get; set; }
    }
}
