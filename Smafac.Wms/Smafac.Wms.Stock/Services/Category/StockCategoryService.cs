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
        private readonly IStockCategoryAddService _categoryAddService;
        private readonly IStockCategoryDeleteService _categoryDeleteService;
        private readonly IStockCategorySearchService _categorySearchService;
        private readonly IStockCategoryUpdateService _categoryUpdateService;

        public StockCategoryService(IStockCategoryAddService categoryAddService,
            IStockCategoryDeleteService categoryDeleteService,
            IStockCategorySearchService categorySearchService,
            IStockCategoryUpdateService categoryUpdateService)
        {
            _categoryAddService = categoryAddService;
            _categoryDeleteService = categoryDeleteService;
            _categorySearchService = categorySearchService;
            _categoryUpdateService = categoryUpdateService;
        }

        public ICategoryAddService<StockCategoryModel> AddService => _categoryAddService;

        public ICategoryDeleteService<StockCategoryModel> DeleteService => _categoryDeleteService;

        public ICategoryUpdateService<StockCategoryModel> UpdateService => _categoryUpdateService;

        public ICategorySearchService<StockCategoryModel> SearchService => _categorySearchService;
    }
}
