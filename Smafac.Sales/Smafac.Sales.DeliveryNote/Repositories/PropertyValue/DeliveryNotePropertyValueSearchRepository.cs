using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Sales.DeliveryNote.Domain;
using Smafac.Sales.DeliveryNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Smafac.Sales.DeliveryNote.Repositories.PropertyValue
{
    class DeliveryNotePropertyValueSearchRepository : PropertyValueSearchRepository<DeliveryNoteContext, DeliveryNotePropertyValueEntity, DeliveryNotePropertyEntity, DeliveryNotePropertyValueModel>
                                                , IDeliveryNotePropertyValueSearchRepository
    {
        public DeliveryNotePropertyValueSearchRepository(IDeliveryNoteContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override Expression<Func<DeliveryNotePropertyValueEntity, bool>> CreateEntityQueryExpression(Guid entityId)
        {
            return s => s.DeliveryNoteId.Equals(entityId);
        }

        protected override Expression<Func<DeliveryNotePropertyValueEntity, bool>> CreateEntityQueryExpression(IEnumerable<Guid> entityIds)
        {
            return s => entityIds.Contains(s.DeliveryNoteId);
        }

        protected override IEnumerable<IGrouping<Guid, DeliveryNotePropertyValueModel>> GroupValues(IEnumerable<DeliveryNotePropertyValueModel> values)
        {
            return values.GroupBy(s => s.DeliveryNoteId);
        }

        protected override IQueryable<DeliveryNotePropertyValueModel> JoinProperty(IQueryable<DeliveryNotePropertyValueEntity> values, IQueryable<DeliveryNotePropertyEntity> properties)
        {
            var query = from value in values
                        join property in properties on value.PropertyId equals property.Id
                        select new DeliveryNotePropertyValueModel
                        {
                            CreateTime = value.CreateTime,
                            SubscriberId = value.SubscriberId,
                            DeliveryNoteId = value.DeliveryNoteId,
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
