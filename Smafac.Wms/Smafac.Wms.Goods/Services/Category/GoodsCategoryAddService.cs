using Smafac.Wms.Goods.Applications.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Wms.Goods.Models;
using Smafac.Framework.Core.Services.Category;
using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Repositories.Category;

namespace Smafac.Wms.Goods.Services.Category
{
    class GoodsCategoryAddService : CategoryAddService<GoodsCategoryEntity, GoodsCategoryModel>, IGoodsCategoryAddService
    {
        public GoodsCategoryAddService(IGoodsCategoryAddRepository goodsCategoryAddRepository,
                                        IGoodsCategorySearchRepository goodsCategorySearchRepository)
        {
            base.CategoryAddRepository = goodsCategoryAddRepository;
            base.CategorySearchRepository = goodsCategorySearchRepository;
        }
    }
}
