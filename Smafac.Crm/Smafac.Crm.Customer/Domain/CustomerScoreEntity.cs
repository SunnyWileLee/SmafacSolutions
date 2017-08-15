using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Domain
{
    [Table("CustomerScore")]
    class CustomerScoreEntity : SaasBaseEntity
    {
        public Guid CustomerId { get; set; }
        public decimal Score { get; set; }
        public Guid LevelId { get; set; }
    }
}
