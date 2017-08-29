using Smafac.Wms.Goods.Applications.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Core.Applications.Category;
using Smafac.Wms.Goods.Models;

namespace Smafac.Wms.Goods.Services.Category
{
    class GoodsCategoryService : IGoodsCategoryService
    {
        private readonly IGoodsCategoryAddService _goodsCategoryAddService;
        private readonly IGoodsCategoryDeleteService _goodsCategoryDeleteService;
        private readonly IGoodsCategorySearchService _goodsCategorySearchService;
        private readonly IGoodsCategoryUpdateService _goodsCategoryUpdateService;

        public GoodsCategoryService(IGoodsCategoryAddService goodsCategoryAddService,
            IGoodsCategoryDeleteService goodsCategoryDeleteService,
            IGoodsCategorySearchService goodsCategorySearchService,
            IGoodsCategoryUpdateService goodsCategoryUpdateService)
        {
            _goodsCategoryAddService = goodsCategoryAddService;
            _goodsCategoryDeleteService = goodsCategoryDeleteService;
            _goodsCategorySearchService = goodsCategorySearchService;
            _goodsCategoryUpdateService = goodsCategoryUpdateService;
        }

        public ICategoryAddService<GoodsCategoryModel> AddService => _goodsCategoryAddService;

        public ICategoryDeleteService<GoodsCategoryModel> DeleteService => _goodsCategoryDeleteService;

        public ICategoryUpdateService<GoodsCategoryModel> UpdateService => _goodsCategoryUpdateService;

        public ICategorySearchService<GoodsCategoryModel> SearchService => _goodsCategorySearchService;
    }
}
