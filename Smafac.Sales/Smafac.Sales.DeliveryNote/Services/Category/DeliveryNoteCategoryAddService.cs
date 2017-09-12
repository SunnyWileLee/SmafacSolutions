using Smafac.Framework.Core.Services.Category;
using Smafac.Sales.DeliveryNote.Applications.Category;
using Smafac.Sales.DeliveryNote.Domain;
using Smafac.Sales.DeliveryNote.Models;
using Smafac.Sales.DeliveryNote.Repositories.Category;

namespace Smafac.Wms.DeliveryNote.Services.Category
{
    class DeliveryNoteCategoryAddService : CategoryAddService<DeliveryNoteCategoryEntity, DeliveryNoteCategoryModel>, IDeliveryNoteCategoryAddService
    {
        public DeliveryNoteCategoryAddService(IDeliveryNoteCategoryAddRepository noteCategoryAddRepository,
                                        IDeliveryNoteCategorySearchRepository noteCategorySearchRepository)
        {
            base.CategoryAddRepository = noteCategoryAddRepository;
            base.CategorySearchRepository = noteCategorySearchRepository;
        }
    }
}
