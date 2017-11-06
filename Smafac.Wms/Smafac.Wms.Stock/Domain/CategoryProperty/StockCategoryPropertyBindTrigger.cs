using Smafac.Framework.Core.Domain.CategoryProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Smafac.Wms.Stock.Repositories;
using Smafac.Wms.Stock.Repositories.PropertyValue;

namespace Smafac.Wms.Stock.Domain.CategoryProperty
{
    class StockCategoryPropertyBindTrigger : CategoryPropertyBindTrigger<StockEntity, StockCategoryEntity, StockPropertyEntity, StockPropertyValueEntity>,
                                            IStockCategoryPropertyBindTrigger
    {
        public StockCategoryPropertyBindTrigger(IStockSearchRepository goodsSearchRepository,
                                                IStockPropertyValueSetRepository goodsPropertyValueSetRepository)
        {
            base.EntitySearchRepository = goodsSearchRepository;
            base.AssociationValueAddRepository = goodsPropertyValueSetRepository;
        }

        protected override void ModifyValue(StockPropertyValueEntity value, Guid goodsId, StockPropertyEntity property)
        {
            base.ModifyValue(value, goodsId, property);
            value.StockId = goodsId;
        }

        protected override Expression<Func<StockEntity, bool>> CreateEntityPredicate(StockCategoryEntity category)
        {
            return goods => goods.CategoryId == category.Id;
        }
    }
}
