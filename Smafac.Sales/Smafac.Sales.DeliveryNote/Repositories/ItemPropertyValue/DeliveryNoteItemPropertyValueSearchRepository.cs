using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Sales.DeliveryNote.Domain;
using Smafac.Sales.DeliveryNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Smafac.Sales.DeliveryNote.Repositories.ItemPropertyValue
{
    class DeliveryNoteItemPropertyValueSearchRepository : PropertyValueSearchRepository<DeliveryNoteContext, DeliveryNoteItemPropertyValueEntity, DeliveryNoteItemPropertyEntity, DeliveryNoteItemPropertyValueModel>
                                                , IDeliveryNoteItemPropertyValueSearchRepository
    {
        public DeliveryNoteItemPropertyValueSearchRepository(IDeliveryNoteContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override Expression<Func<DeliveryNoteItemPropertyValueEntity, bool>> CreateEntityQueryExpression(Guid entityId)
        {
            return s => s.DeliveryNoteItemId.Equals(entityId);
        }

        protected override Expression<Func<DeliveryNoteItemPropertyValueEntity, bool>> CreateEntityQueryExpression(IEnumerable<Guid> entityIds)
        {
            return s => entityIds.Contains(s.DeliveryNoteItemId);
        }

        protected override IEnumerable<IGrouping<Guid, DeliveryNoteItemPropertyValueModel>> GroupValues(IEnumerable<DeliveryNoteItemPropertyValueModel> values)
        {
            return values.GroupBy(s => s.DeliveryNoteItemId);
        }

        protected override IQueryable<DeliveryNoteItemPropertyValueModel> JoinProperty(IQueryable<DeliveryNoteItemPropertyValueEntity> values, IQueryable<DeliveryNoteItemPropertyEntity> properties)
        {
            var query = from value in values
                        join property in properties on value.PropertyId equals property.Id
                        select new DeliveryNoteItemPropertyValueModel
                        {
                            CreateTime = value.CreateTime,
                            SubscriberId = value.SubscriberId,
                            DeliveryNoteItemId = value.DeliveryNoteItemId,
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
