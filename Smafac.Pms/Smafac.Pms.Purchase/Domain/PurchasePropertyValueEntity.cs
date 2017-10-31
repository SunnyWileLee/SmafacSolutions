﻿using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Domain
{
    [Table("PurchasePropertyValue")]
    class PurchasePropertyValueEntity : PropertyValueEntity
    {
        public Guid PurchaseId { get; set; }
    }
}
