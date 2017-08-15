﻿using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Domain
{
    [Table("CustomerLevel")]
    class CustomerLevelEntity : SaasBaseEntity
    {
        public string Title { get; set; }
        public decimal Buttom { get; set; }
        public decimal Top { get; set; }
    }
}
