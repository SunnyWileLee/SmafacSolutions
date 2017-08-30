using Smafac.Framework.Core.Services.CategoryProperty;
using Smafac.Wms.Goods.Applications.CategoryProperty;
using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Models;
using Smafac.Wms.Goods.Repositories.CategoryProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Services.CategoryProperty
{
    class GoodsCategoryPropertySearchService : CategoryPropertySearchService<GoodsCategoryEntity, GoodsPropertyEntity, GoodsPropertyModel>,
                                                IGoodsCategoryPropertySearchService
    {
        public GoodsCategoryPropertySearchService(IGoodsCategoryPropertySearchRepository goodsCategoryPropertySearchRepository,
            IGoodsCategoryPropertyProvider goodsCategoryPropertyProvider
            )
        {
            base.CategoryPropertyProvider = goodsCategoryPropertyProvider;
            base.CategoryPropertySearchRepository = goodsCategoryPropertySearchRepository;
        }
    }
}
