using Smafac.Framework.Core.Domain.Property;
using Smafac.Wms.Goods.Repositories.CategoryProperty;

namespace Smafac.Wms.Goods.Domain.Property
{
    class GoodsPropertyUsedByCategoryChecker : PropertyUsedByCategoryChecker<GoodsCategoryEntity, GoodsPropertyEntity>,
                                                IGoodsPropertyUsedChecker
    {
        public GoodsPropertyUsedByCategoryChecker(IGoodsCategoryPropertySearchRepository goodsategoryPropertySearchRepository)
        {
            base.CategoryPropertySearchRepository = goodsategoryPropertySearchRepository;
        }
    }
}
