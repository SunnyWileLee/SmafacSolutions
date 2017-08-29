using Smafac.Framework.Core.Services.Category;
using Smafac.Wms.Goods.Applications.Category;
using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Models;
using Smafac.Wms.Goods.Repositories.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Services.Category
{
    class GoodsCategorySearchService : CategorySearchService<GoodsCategoryEntity, GoodsCategoryModel>, IGoodsCategorySearchService
    {
        public GoodsCategorySearchService(IGoodsCategorySearchRepository goodsSearchRepository,
            IGoodsPropertyProvider goodsCategoryProvider)
        {
            base.CategorySearchRepository = goodsSearchRepository;
        }
    }
}
