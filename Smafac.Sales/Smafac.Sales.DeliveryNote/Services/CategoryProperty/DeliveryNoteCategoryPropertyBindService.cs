using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Framework.Core.Services.CategoryProperty;
using Smafac.Sales.DeliveryNote.Applications.CategoryProperty;
using Smafac.Sales.DeliveryNote.Domain;
using Smafac.Sales.DeliveryNote.Domain.CategoryProperty;
using Smafac.Sales.DeliveryNote.Repositories.Category;
using Smafac.Sales.DeliveryNote.Repositories.CategoryProperty;
using Smafac.Sales.DeliveryNote.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.DeliveryNote.Services.CategoryProperty
{
    class DeliveryNoteCategoryPropertyBindService : CategoryPropertyBindService<DeliveryNoteCategoryEntity, DeliveryNotePropertyEntity>,
                                        IDeliveryNoteCategoryPropertyBindService
    {
        public DeliveryNoteCategoryPropertyBindService(IDeliveryNoteCategoryPropertyBindRepository categoryPropertyBindRepository,
                                                IDeliveryNoteCategoryPropertySearchRepository categoryPropertySearchRepository,
                                                IEnumerable<IDeliveryNoteCategoryPropertyBindTrigger> categoryPropertyBindTriggers,
                                                IDeliveryNoteCategorySearchRepository categorySearchRepository,
                                                IDeliveryNotePropertySearchRepository propertySearchRepository
                                                )
        {
            base.EntityAssociationBindRepository = categoryPropertyBindRepository;
            base.EntityAssociationSearchRepository = categoryPropertySearchRepository;
            base.CategoryAssociationBindTriggers = categoryPropertyBindTriggers;
            base.CategorySearchRepository = categorySearchRepository;
            base.AssociationSearchRepository = propertySearchRepository;
        }

    }
}
