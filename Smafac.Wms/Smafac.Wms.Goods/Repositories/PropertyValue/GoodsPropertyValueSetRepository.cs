using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Wms.Goods.Domain;
using System;
using System.Linq;

namespace Smafac.Wms.Goods.Repositories.PropertyValue
{
    class GoodsPropertyValueSetRepository : PropertyValueSetRepository<GoodsContext, GoodsPropertyValueEntity>
                                                , IGoodsPropertyValueSetRepository
    {
        public GoodsPropertyValueSetRepository(IGoodsContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override bool HasSetValue(IQueryable<GoodsPropertyValueEntity> values, Guid entityId)
        {
            return values.Any(s => s.GoodsId.Equals(entityId));
        }

        protected override bool VerifyEntityId(Guid entityId, GoodsPropertyValueEntity value)
        {
            return !entityId.Equals(value.GoodsId);
        }
    }
}
