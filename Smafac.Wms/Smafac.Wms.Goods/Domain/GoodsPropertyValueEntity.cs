﻿using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Domain
{
    [Table("GoodsPropertyValue")]
    class GoodsPropertyValueEntity : PropertyValueEntity
    {
        public Guid GoodsId { get; set; }
    }
}
