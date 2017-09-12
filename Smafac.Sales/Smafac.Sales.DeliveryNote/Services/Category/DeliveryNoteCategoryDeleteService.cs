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
    class DeliveryNoteCategoryDeleteService : CategoryDeleteService<DeliveryNoteCategoryEntity, DeliveryNoteCategoryModel>, IDeliveryNoteCategoryDeleteService
    {
        public DeliveryNoteCategoryDeleteService(IDeliveryNoteCategoryDeleteRepository noteCategoryDeleteRepository)
        {
            base.CategoryDeleteRepository = noteCategoryDeleteRepository;
        }

        protected override bool IsUsed(Guid CategoryId)
        {
            return false;
        }
    }
}
