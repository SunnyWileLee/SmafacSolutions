using Smafac.Framework.Core.Domain.EntityAssociationProviders;
using Smafac.Wms.Goods.Models;
using Smafac.Wms.Goods.Repositories.Category;
using Smafac.Wms.Goods.Repositories.CategoryProperty;

namespace Smafac.Wms.Goods.Domain.CategoryProperty
{
    class GoodsCategoryPropertyProvider : CategoryPropertyProvider<GoodsCategoryEntity, GoodsPropertyEntity, GoodsPropertyModel>,
                                            IGoodsCategoryPropertyProvider
    {

        public GoodsCategoryPropertyProvider(IGoodsCategoryPropertySearchRepository goodsCategoryPropertySearchRepository,
                                            IGoodsCategorySearchRepository goodsCategorySearchRepository)
        {
            base.CategorySearchRepository = goodsCategorySearchRepository;
            base.CategoryAssociationSearchRepository = goodsCategoryPropertySearchRepository;
        }
    }
}
