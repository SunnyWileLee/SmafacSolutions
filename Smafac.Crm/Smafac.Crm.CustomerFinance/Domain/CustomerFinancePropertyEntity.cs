using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.CustomerFinance.Domain
{
    [Table("CustomerFinanceProperty")]
    class CustomerFinancePropertyEntity : PropertyEntity
    {

        public CustomerFinancePropertyValueEntity CreateEmptyValue()
        {
            return this.CreateValue(Guid.Empty, string.Empty);
        }

        public CustomerFinancePropertyValueEntity CreateValue(Guid financeId, string value)
        {
            return new CustomerFinancePropertyValueEntity
            {
                CustomerFinanceId = financeId,
                Value = value,
                PropertyId = this.Id,
                SubscriberId = this.SubscriberId
            };
        }
    }
}
