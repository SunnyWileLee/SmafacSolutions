﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Framework.Models
{
    public class PropertyModel : SaasBaseModel
    {
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
    }
}
