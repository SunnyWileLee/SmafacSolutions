﻿using Smafac.Sales.DeliveryNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Presentation.Domain.DeliveryNote
{
    public interface IDeliveryNoteWrapper
    {
        void Wrapper(List<DeliveryNoteModel> notes);
    }
}
