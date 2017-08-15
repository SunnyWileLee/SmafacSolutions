﻿using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Domain
{
    [Table("CustomerFinancialStatus")]
    class CustomerFinancialStatusEntity : SaasBaseEntity
    {
        public string Title { get; set; }
    }
}
