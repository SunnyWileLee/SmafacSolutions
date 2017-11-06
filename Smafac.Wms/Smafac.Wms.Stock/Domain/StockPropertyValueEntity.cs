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
    [Table("StockPropertyValue")]
    class StockPropertyValueEntity : PropertyValueEntity
    {
        public Guid StockId { get; set; }
    }
}
