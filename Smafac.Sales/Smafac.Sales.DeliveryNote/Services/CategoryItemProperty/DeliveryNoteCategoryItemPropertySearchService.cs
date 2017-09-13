using Smafac.Framework.Core.Services.CategoryProperty;
using Smafac.Sales.DeliveryNote.Applications.CategoryItemProperty;
using Smafac.Sales.DeliveryNote.Domain;
using Smafac.Sales.DeliveryNote.Domain.CategoryItemProperty;
using Smafac.Sales.DeliveryNote.Models;
using Smafac.Sales.DeliveryNote.Repositories.CategoryItemProperty;

namespace Smafac.Sales.DeliveryNote.Services.CategoryItemProperty
{
    class DeliveryNoteCategoryItemPropertySearchService : CategoryPropertySearchService<DeliveryNoteCategoryEntity, DeliveryNoteItemPropertyEntity, DeliveryNoteItemPropertyModel>,
                                                IDeliveryNoteCategoryItemPropertySearchService
    {
        public DeliveryNoteCategoryItemPropertySearchService(IDeliveryNoteCategoryItemPropertySearchRepository ctegoryItemPropertySearchRepository,
                                                        IDeliveryNoteCategoryItemPropertyProvider categoryItemPropertyProvider
                                                        )
        {

            base.CategoryAssociationProvider = categoryItemPropertyProvider;
            base.EntityAssociationSearchRepository = ctegoryItemPropertySearchRepository;
        }
    }
}
