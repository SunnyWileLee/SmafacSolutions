using Smafac.Pms.Purchase.Applications.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Core.Applications.Category;
using Smafac.Pms.Purchase.Models;

namespace Smafac.Pms.Purchase.Services.Category
{
    class PurchaseCategoryService : IPurchaseCategoryService
    {
        private readonly IPurchaseCategoryAddService _categoryAddService;
        private readonly IPurchaseCategoryDeleteService _categoryDeleteService;
        private readonly IPurchaseCategorySearchService _categorySearchService;
        private readonly IPurchaseCategoryUpdateService _categoryUpdateService;

        public PurchaseCategoryService(IPurchaseCategoryAddService categoryAddService,
            IPurchaseCategoryDeleteService categoryDeleteService,
            IPurchaseCategorySearchService categorySearchService,
            IPurchaseCategoryUpdateService categoryUpdateService)
        {
            _categoryAddService = categoryAddService;
            _categoryDeleteService = categoryDeleteService;
            _categorySearchService = categorySearchService;
            _categoryUpdateService = categoryUpdateService;
        }

        public ICategoryAddService<PurchaseCategoryModel> AddService => _categoryAddService;

        public ICategoryDeleteService<PurchaseCategoryModel> DeleteService => _categoryDeleteService;

        public ICategoryUpdateService<PurchaseCategoryModel> UpdateService => _categoryUpdateService;

        public ICategorySearchService<PurchaseCategoryModel> SearchService => _categorySearchService;
    }
}
