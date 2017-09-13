using Smafac.Framework.Core.Domain.Property;
using Smafac.Sales.DeliveryNote.Repositories.CategoryItemProperty;

namespace Smafac.Sales.DeliveryNote.Domain.ItemProperty
{
    class CustomerItemPropertyDeleteCategoryTrigger : PropertyDeleteCategoryTrigger<DeliveryNoteCategoryEntity, DeliveryNoteItemPropertyEntity, DeliveryNoteCategoryItemPropertyEntity>,
        IDeliveryNoteItemPropertyDeleteTrigger
    {
        public CustomerItemPropertyDeleteCategoryTrigger(IDeliveryNoteCategoryItemPropertyBindRepository categoryPropertyBindRepository)
        {
            base.CategoryPropertyBindRepository = categoryPropertyBindRepository;
        }
    }
}
