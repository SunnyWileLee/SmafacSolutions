using Smafac.Framework.Core.Domain.CategoryProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Domain.CategoryProperty
{
    interface IDeliveryNoteCategoryPropertyBindTrigger: ICategoryPropertyBindTrigger<DeliveryNoteCategoryEntity, DeliveryNotePropertyEntity>
    {
    }
}
