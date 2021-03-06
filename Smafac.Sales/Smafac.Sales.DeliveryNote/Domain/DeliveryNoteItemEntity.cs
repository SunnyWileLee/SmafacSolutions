﻿using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Domain
{
    [Table("DeliveryNoteItem")]
    class DeliveryNoteItemEntity : SaasBaseEntity
    {
        public Guid DeliveryNoteId { get; set; }
        public Guid GoodsId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}
