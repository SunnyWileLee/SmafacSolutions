﻿using Smafac.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Domain
{
    [Table("DeliveryNoteItemPropertyValue")]
    class DeliveryNoteItemPropertyValueEntity : PropertyValueEntity
    {
        public Guid DeliveryNoteItemId { get; set; }
    }
}
