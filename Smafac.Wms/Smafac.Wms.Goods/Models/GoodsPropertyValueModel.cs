﻿using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Models
{
    public class GoodsPropertyValueModel : PropertyValueModel
    {
        public Guid GoodsId { get; set; }
    }
}
