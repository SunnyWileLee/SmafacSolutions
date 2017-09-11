using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Sales.DeliveryNote.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Repositories.CategoryProperty
{
    class DeliveryNoteCategoryPropertyBindRepository : CategoryPropertyBindRepository<DeliveryNoteContext, DeliveryNoteCategoryEntity, DeliveryNotePropertyEntity, DeliveryNoteCategoryPropertyEntity>,
                                                IDeliveryNoteCategoryPropertyBindRepository
    {
        public DeliveryNoteCategoryPropertyBindRepository(IDeliveryNoteContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
