﻿using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Models
{
    public class GoodsModel : SaasBaseModel
    {
        [Display(Name = "名称")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "售价")]
        [Required]
        public decimal Price { get; set; }
    }
}
