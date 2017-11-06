using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Wms.Stock.Domain;
using Smafac.Wms.Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Smafac.Wms.Stock.Repositories.PropertyValue
{
    class StockPropertyValueSearchRepository : PropertyValueSearchRepository<StockContext, StockPropertyValueEntity, StockPropertyEntity, StockPropertyValueModel>
                                                , IStockPropertyValueSearchRepository
    {
        public StockPropertyValueSearchRepository(IStockContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override Expression<Func<StockPropertyValueEntity, bool>> CreateEntityQueryExpression(Guid entityId)
        {
            return s => s.StockId.Equals(entityId);
        }

        protected override Expression<Func<StockPropertyValueEntity, bool>> CreateEntityQueryExpression(IEnumerable<Guid> entityIds)
        {
            return s => entityIds.Contains(s.StockId);
        }

        protected override IEnumerable<IGrouping<Guid, StockPropertyValueModel>> GroupValues(IEnumerable<StockPropertyValueModel> values)
        {
            return values.GroupBy(s => s.StockId);
        }

        protected override IQueryable<StockPropertyValueModel> JoinProperty(IQueryable<StockPropertyValueEntity> values, IQueryable<StockPropertyEntity> properties)
        {
            var query = from value in values
                        join property in properties on value.PropertyId equals property.Id
                        select new StockPropertyValueModel
                        {
                            CreateTime = value.CreateTime,
                            SubscriberId = value.SubscriberId,
                            StockId = value.StockId,
                            Id = value.Id,
                            PropertyId = value.PropertyId,
                            Value = value.Value,
                            IsTableColumn = property.IsTableColumn,
                            PropertyName = property.Name,
                            Type = property.Type
                        };
            return query;
        }
    }
}
