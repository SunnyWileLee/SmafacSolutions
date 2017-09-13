using Smafac.Framework.Core.Domain.EntityAssociationProviders;
using Smafac.Sales.DeliveryNote.Models;
using Smafac.Sales.DeliveryNote.Repositories.Category;
using Smafac.Sales.DeliveryNote.Repositories.CategoryItemProperty;

namespace Smafac.Sales.DeliveryNote.Domain.CategoryItemProperty
{
    class DeliveryNoteCategoryItemPropertyProvider: CategoryPropertyProvider<DeliveryNoteCategoryEntity, DeliveryNoteItemPropertyEntity, DeliveryNoteItemPropertyModel> ,
                                        IDeliveryNoteCategoryItemPropertyProvider
    {
        public DeliveryNoteCategoryItemPropertyProvider(IDeliveryNoteCategorySearchRepository categorySearchRepository,
                                               IDeliveryNoteCategoryItemPropertySearchRepository categoryPropertySearchRepository)
        {
            base.CategorySearchRepository = categorySearchRepository;
            base.CategoryAssociationSearchRepository = categoryPropertySearchRepository;
        }
    }
}
