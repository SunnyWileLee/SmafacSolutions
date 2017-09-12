using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Core.Applications.Category;
using Smafac.Sales.DeliveryNote.Applications.Category;
using Smafac.Sales.DeliveryNote.Models;

namespace Smafac.Wms.DeliveryNote.Services.Category
{
    class DeliveryNoteCategoryService : IDeliveryNoteCategoryService
    {
        private readonly IDeliveryNoteCategoryAddService _noteCategoryAddService;
        private readonly IDeliveryNoteCategoryDeleteService _noteCategoryDeleteService;
        private readonly IDeliveryNoteCategorySearchService _noteCategorySearchService;
        private readonly IDeliveryNoteCategoryUpdateService _noteCategoryUpdateService;

        public DeliveryNoteCategoryService(IDeliveryNoteCategoryAddService noteCategoryAddService,
            IDeliveryNoteCategoryDeleteService noteCategoryDeleteService,
            IDeliveryNoteCategorySearchService noteCategorySearchService,
            IDeliveryNoteCategoryUpdateService noteCategoryUpdateService)
        {
            _noteCategoryAddService = noteCategoryAddService;
            _noteCategoryDeleteService = noteCategoryDeleteService;
            _noteCategorySearchService = noteCategorySearchService;
            _noteCategoryUpdateService = noteCategoryUpdateService;
        }

        public ICategoryAddService<DeliveryNoteCategoryModel> AddService => _noteCategoryAddService;

        public ICategoryDeleteService<DeliveryNoteCategoryModel> DeleteService => _noteCategoryDeleteService;

        public ICategoryUpdateService<DeliveryNoteCategoryModel> UpdateService => _noteCategoryUpdateService;

        public ICategorySearchService<DeliveryNoteCategoryModel> SearchService => _noteCategorySearchService;
    }
}
