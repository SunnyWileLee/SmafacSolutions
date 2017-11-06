using Smafac.Wms.Stock.Applications.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Core.Applications.Category;
using Smafac.Wms.Stock.Models;

namespace Smafac.Wms.Stock.Services.Category
{
    class StockCategoryService : IStockCategoryService
    {
        private readonly IStockCategoryAddService _goodsCategoryAddService;
        private readonly IStockCategoryDeleteService _goodsCategoryDeleteService;
        private readonly IStockCategorySearchService _goodsCategorySearchService;
        private readonly IStockCategoryUpdateService _goodsCategoryUpdateService;

        public StockCategoryService(IStockCategoryAddService goodsCategoryAddService,
            IStockCategoryDeleteService goodsCategoryDeleteService,
            IStockCategorySearchService goodsCategorySearchService,
            IStockCategoryUpdateService goodsCategoryUpdateService)
        {
            _goodsCategoryAddService = goodsCategoryAddService;
            _goodsCategoryDeleteService = goodsCategoryDeleteService;
            _goodsCategorySearchService = goodsCategorySearchService;
            _goodsCategoryUpdateService = goodsCategoryUpdateService;
        }

        public ICategoryAddService<StockCategoryModel> AddService => _goodsCategoryAddService;

        public ICategoryDeleteService<StockCategoryModel> DeleteService => _goodsCategoryDeleteService;

        public ICategoryUpdateService<StockCategoryModel> UpdateService => _goodsCategoryUpdateService;

        public ICategorySearchService<StockCategoryModel> SearchService => _goodsCategorySearchService;
    }
}
