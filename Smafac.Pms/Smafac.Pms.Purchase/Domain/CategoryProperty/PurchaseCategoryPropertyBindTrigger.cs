using Smafac.Framework.Core.Domain.CategoryProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Smafac.Pms.Purchase.Repositories;
using Smafac.Pms.Purchase.Repositories.PropertyValue;

namespace Smafac.Pms.Purchase.Domain.CategoryProperty
{
    class PurchaseCategoryPropertyBindTrigger : CategoryPropertyBindTrigger<PurchaseEntity, PurchaseCategoryEntity, PurchasePropertyEntity, PurchasePropertyValueEntity>,
                                            IPurchaseCategoryPropertyBindTrigger
    {
        public PurchaseCategoryPropertyBindTrigger(IPurchaseSearchRepository goodsSearchRepository,
                                                IPurchasePropertyValueSetRepository goodsPropertyValueSetRepository)
        {
            base.EntitySearchRepository = goodsSearchRepository;
            base.AssociationValueAddRepository = goodsPropertyValueSetRepository;
        }

        protected override void ModifyValue(PurchasePropertyValueEntity value, Guid goodsId, PurchasePropertyEntity property)
        {
            base.ModifyValue(value, goodsId, property);
            value.PurchaseId = goodsId;
        }

        protected override Expression<Func<PurchaseEntity, bool>> CreateEntityPredicate(PurchaseCategoryEntity category)
        {
            return goods => goods.CategoryId == category.Id;
        }
    }
}
