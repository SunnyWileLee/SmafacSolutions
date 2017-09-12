using Smafac.Framework.Core.Domain.Property;
using Smafac.Sales.DeliveryNote.Repositories.CategoryProperty;

namespace Smafac.Sales.DeliveryNote.Domain.Property
{
    class CustomerPropertyDeleteCategoryTrigger : PropertyDeleteCategoryTrigger<DeliveryNoteCategoryEntity, DeliveryNotePropertyEntity, DeliveryNoteCategoryPropertyEntity>,
        IDeliveryNotePropertyDeleteTrigger
    {
        public CustomerPropertyDeleteCategoryTrigger(IDeliveryNoteCategoryPropertyBindRepository categoryPropertyBindRepository)
        {
            base.CategoryPropertyBindRepository = categoryPropertyBindRepository;
        }
    }
}
