using Smafac.Framework.Core.Repositories.Category;
using Smafac.Sales.DeliveryNote.Domain;
using Smafac.Sales.DeliveryNote.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Repositories.Category
{
    class DeliveryNoteCategorySearchRepository : CategorySearchRepository<DeliveryNoteContext, DeliveryNoteCategoryEntity>, IDeliveryNoteCategorySearchRepository
    {
        public DeliveryNoteCategorySearchRepository(IDeliveryNoteContextProvider orderContextProvider)
        {
            base.ContextProvider = orderContextProvider;
        }
    }
}
