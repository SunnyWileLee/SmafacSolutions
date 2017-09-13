using Smafac.Framework.Core.Services.CategoryProperty;
using Smafac.Sales.DeliveryNote.Applications.CategoryItemProperty;
using Smafac.Sales.DeliveryNote.Domain;
using Smafac.Sales.DeliveryNote.Domain.CategoryItemProperty;
using Smafac.Sales.DeliveryNote.Repositories.Category;
using Smafac.Sales.DeliveryNote.Repositories.CategoryItemProperty;
using Smafac.Sales.DeliveryNote.Repositories.ItemProperty;
using System.Collections.Generic;

namespace Smafac.Sales.DeliveryNote.Services.CategoryItemProperty
{
    class DeliveryNoteCategoryItemPropertyBindService : CategoryPropertyBindService<DeliveryNoteCategoryEntity, DeliveryNoteItemPropertyEntity>,
                                        IDeliveryNoteCategoryItemPropertyBindService
    {
        public DeliveryNoteCategoryItemPropertyBindService(IDeliveryNoteCategoryItemPropertyBindRepository categoryItemPropertyBindRepository,
                                                IDeliveryNoteCategoryItemPropertySearchRepository categoryItemPropertySearchRepository,
                                                IEnumerable<IDeliveryNoteCategoryItemPropertyBindTrigger> categoryItemPropertyBindTriggers,
                                                IDeliveryNoteCategorySearchRepository categorySearchRepository,
                                                IDeliveryNoteItemPropertySearchRepository propertySearchRepository
                                                )
        {
            base.EntityAssociationBindRepository = categoryItemPropertyBindRepository;
            base.EntityAssociationSearchRepository = categoryItemPropertySearchRepository;
            base.CategoryAssociationBindTriggers = categoryItemPropertyBindTriggers;
            base.CategorySearchRepository = categorySearchRepository;
            base.AssociationSearchRepository = propertySearchRepository;
        }

    }
}
