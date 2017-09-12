using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Domain
{
    [Table("DeliveryNoteProperty")]
    class DeliveryNotePropertyEntity : PropertyEntity
    {
        public DeliveryNotePropertyValueEntity CreateEmptyValue()
        {
            return new DeliveryNotePropertyValueEntity
            {
                PropertyId = this.Id,
                SubscriberId = this.SubscriberId
            };
        }
    }
}
