using Smafac.Framework.Core.Domain.CategoryProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Smafac.Wms.Goods.Repositories;
using Smafac.Wms.Goods.Repositories.PropertyValue;

namespace Smafac.Wms.Goods.Domain.CategoryProperty
{
    class GoodsCategoryPropertyBindTrigger : CategoryPropertyBindTrigger<GoodsEntity, GoodsCategoryEntity, GoodsPropertyEntity, GoodsPropertyValueEntity>,
                                            IGoodsCategoryPropertyBindTrigger
    {
        public GoodsCategoryPropertyBindTrigger(IGoodsSearchRepository goodsSearchRepository,
                                                IGoodsPropertyValueSetRepository goodsPropertyValueSetRepository)
        {
            base.EntitySearchRepository = goodsSearchRepository;
            base.AssociationValueAddRepository = goodsPropertyValueSetRepository;
        }

        protected override void ModifyValue(GoodsPropertyValueEntity value, Guid goodsId, GoodsPropertyEntity property)
        {
            base.ModifyValue(value, goodsId, property);
            value.GoodsId = goodsId;
        }

        protected override Expression<Func<GoodsEntity, bool>> CreateEntityPredicate(GoodsCategoryEntity category)
        {
            return goods => goods.CategoryId == category.Id;
        }
    }
}
