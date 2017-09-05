using Smafac.Framework.Core.Domain.Property;
using Smafac.Wms.Goods.Repositories.CategoryProperty;

namespace Smafac.Wms.Goods.Domain.Property
{
    class CustomerPropertyDeleteCategoryTrigger : PropertyDeleteCategoryTrigger<GoodsCategoryEntity, GoodsPropertyEntity, GoodsCategoryPropertyEntity>,
        IGoodsPropertyDeleteTrigger
    {
        public CustomerPropertyDeleteCategoryTrigger(IGoodsCategoryPropertyBindRepository goodsCategoryPropertyBindRepository)
        {
            base.CategoryPropertyBindRepository = goodsCategoryPropertyBindRepository;
        }
    }
}
