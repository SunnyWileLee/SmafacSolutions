﻿using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Domain
{
    [Table("DeliveryNote")]
    class DeliveryNoteEntity : SaasBaseEntity
    {
        public DeliveryNoteEntity()
        {
            DeliveryTime = DateTime.Now;
        }

        public Guid CustomerId { get; set; }
        public DateTime DeliveryTime { get; set; }
        public decimal Amount { get; set; }
        public Guid CategoryId { get; set; }
        [MaxLength(500)]
        public string Memo { get; set; }
    }
}
