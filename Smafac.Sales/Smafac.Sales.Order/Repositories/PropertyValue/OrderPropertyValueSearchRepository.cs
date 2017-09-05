using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Smafac.Sales.Order.Repositories.PropertyValue
{
    class OrderPropertyValueSearchRepository : PropertyValueSearchRepository<OrderContext, OrderPropertyValueEntity, OrderPropertyEntity, OrderPropertyValueModel>
                                                , IOrderPropertyValueSearchRepository
    {
        public OrderPropertyValueSearchRepository(IOrderContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override Expression<Func<OrderPropertyValueEntity, bool>> CreateEntityQueryExpression(Guid entityId)
        {
            return s => s.OrderId.Equals(entityId);
        }

        protected override Expression<Func<OrderPropertyValueEntity, bool>> CreateEntityQueryExpression(IEnumerable<Guid> entityIds)
        {
            return s => entityIds.Contains(s.OrderId);
        }

        protected override IEnumerable<IGrouping<Guid, OrderPropertyValueModel>> GroupValues(IEnumerable<OrderPropertyValueModel> values)
        {
            return values.GroupBy(s => s.OrderId);
        }

        protected override IQueryable<OrderPropertyValueModel> JoinProperty(IQueryable<OrderPropertyValueEntity> values, IQueryable<OrderPropertyEntity> properties)
        {
            var query = from value in values
                        join property in properties on value.PropertyId equals property.Id
                        select new OrderPropertyValueModel
                        {
                            CreateTime = value.CreateTime,
                            SubscriberId = value.SubscriberId,
                            OrderId = value.OrderId,
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
