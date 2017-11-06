using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Wms.Stock.Domain;
using System;
using System.Linq;

namespace Smafac.Wms.Stock.Repositories.PropertyValue
{
    class StockPropertyValueSetRepository : PropertyValueSetRepository<StockContext, StockPropertyValueEntity>
                                                , IStockPropertyValueSetRepository
    {
        public StockPropertyValueSetRepository(IStockContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override bool HasSetValue(IQueryable<StockPropertyValueEntity> values, Guid entityId)
        {
            return values.Any(s => s.StockId.Equals(entityId));
        }

        protected override bool VerifyEntityId(Guid entityId, StockPropertyValueEntity value)
        {
            return !entityId.Equals(value.StockId);
        }
    }
}
