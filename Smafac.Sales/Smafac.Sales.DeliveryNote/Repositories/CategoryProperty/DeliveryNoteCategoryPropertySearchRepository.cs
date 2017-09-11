using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Sales.DeliveryNote.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Repositories.CategoryProperty
{
    class DeliveryNoteCategoryPropertySearchRepository : CategoryPropertySearchRepository<DeliveryNoteContext, DeliveryNoteCategoryEntity, DeliveryNotePropertyEntity, DeliveryNoteCategoryPropertyEntity>,
                                                  IDeliveryNoteCategoryPropertySearchRepository
    {
        public DeliveryNoteCategoryPropertySearchRepository(IDeliveryNoteContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
