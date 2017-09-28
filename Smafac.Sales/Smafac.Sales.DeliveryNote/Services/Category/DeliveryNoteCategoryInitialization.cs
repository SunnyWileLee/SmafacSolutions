using Smafac.Framework.Core.Applications;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Services.Category;
using Smafac.Sales.DeliveryNote.Domain;
using Smafac.Sales.DeliveryNote.Repositories.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.DeliveryNote.Services.Category
{
    class DeliveryNoteCategoryInitialization : CategoryInitialization<DeliveryNoteCategoryEntity>
    {
        public DeliveryNoteCategoryInitialization(IDeliveryNoteCategoryAddRepository deliveryNoteCategoryAddRepository,
                                        IDeliveryNoteCategorySearchRepository deliveryNoteCategorySearchRepository
                                        )
        {
            base.CategoryAddRepository = deliveryNoteCategoryAddRepository;
            base.CategorySearchRepository = deliveryNoteCategorySearchRepository;
        }
    }
}
