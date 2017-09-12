using Smafac.Framework.Core.Services.Category;
using Smafac.Sales.DeliveryNote.Applications.Category;
using Smafac.Sales.DeliveryNote.Domain;
using Smafac.Sales.DeliveryNote.Models;
using Smafac.Sales.DeliveryNote.Repositories.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.DeliveryNote.Services.Category
{
    class DeliveryNoteCategoryUpdateService : CategoryUpdateService<DeliveryNoteCategoryEntity, DeliveryNoteCategoryModel>, IDeliveryNoteCategoryUpdateService
    {
        public DeliveryNoteCategoryUpdateService(IDeliveryNoteCategorySearchRepository noteCategorySearchRepository,
                                          IDeliveryNoteCategoryUpdateRepository noteCategoryUpdateRepository)
        {
            base.CategorySearchRepository = noteCategorySearchRepository;
            base.CategoryUpdateRepository = noteCategoryUpdateRepository;
        }
    }
}
