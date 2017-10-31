using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Pms.Purchase.Domain;
using Smafac.Pms.Purchase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Smafac.Pms.Purchase.Repositories.PropertyValue
{
    class PurchasePropertyValueSearchRepository : PropertyValueSearchRepository<PurchaseContext, PurchasePropertyValueEntity, PurchasePropertyEntity, PurchasePropertyValueModel>
                                                , IPurchasePropertyValueSearchRepository
    {
        public PurchasePropertyValueSearchRepository(IPurchaseContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override Expression<Func<PurchasePropertyValueEntity, bool>> CreateEntityQueryExpression(Guid entityId)
        {
            return s => s.PurchaseId.Equals(entityId);
        }

        protected override Expression<Func<PurchasePropertyValueEntity, bool>> CreateEntityQueryExpression(IEnumerable<Guid> entityIds)
        {
            return s => entityIds.Contains(s.PurchaseId);
        }

        protected override IEnumerable<IGrouping<Guid, PurchasePropertyValueModel>> GroupValues(IEnumerable<PurchasePropertyValueModel> values)
        {
            return values.GroupBy(s => s.PurchaseId);
        }

        protected override IQueryable<PurchasePropertyValueModel> JoinProperty(IQueryable<PurchasePropertyValueEntity> values, IQueryable<PurchasePropertyEntity> properties)
        {
            var query = from value in values
                        join property in properties on value.PropertyId equals property.Id
                        select new PurchasePropertyValueModel
                        {
                            CreateTime = value.CreateTime,
                            SubscriberId = value.SubscriberId,
                            PurchaseId = value.PurchaseId,
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
