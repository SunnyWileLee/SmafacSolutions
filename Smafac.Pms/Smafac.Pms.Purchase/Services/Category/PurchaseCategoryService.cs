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
        private readonly IPurchaseCategoryAddService _goodsCategoryAddService;
        private readonly IPurchaseCategoryDeleteService _goodsCategoryDeleteService;
        private readonly IPurchaseCategorySearchService _goodsCategorySearchService;
        private readonly IPurchaseCategoryUpdateService _goodsCategoryUpdateService;

        public PurchaseCategoryService(IPurchaseCategoryAddService goodsCategoryAddService,
            IPurchaseCategoryDeleteService goodsCategoryDeleteService,
            IPurchaseCategorySearchService goodsCategorySearchService,
            IPurchaseCategoryUpdateService goodsCategoryUpdateService)
        {
            _goodsCategoryAddService = goodsCategoryAddService;
            _goodsCategoryDeleteService = goodsCategoryDeleteService;
            _goodsCategorySearchService = goodsCategorySearchService;
            _goodsCategoryUpdateService = goodsCategoryUpdateService;
        }

        public ICategoryAddService<PurchaseCategoryModel> AddService => _goodsCategoryAddService;

        public ICategoryDeleteService<PurchaseCategoryModel> DeleteService => _goodsCategoryDeleteService;

        public ICategoryUpdateService<PurchaseCategoryModel> UpdateService => _goodsCategoryUpdateService;

        public ICategorySearchService<PurchaseCategoryModel> SearchService => _goodsCategorySearchService;
    }
}
