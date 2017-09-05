using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Smafac.Wms.Goods.Repositories.PropertyValue
{
    class GoodsPropertyValueSearchRepository : PropertyValueSearchRepository<GoodsContext, GoodsPropertyValueEntity, GoodsPropertyEntity, GoodsPropertyValueModel>
                                                , IGoodsPropertyValueSearchRepository
    {
        public GoodsPropertyValueSearchRepository(IGoodsContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override Expression<Func<GoodsPropertyValueEntity, bool>> CreateEntityQueryExpression(Guid entityId)
        {
            return s => s.GoodsId.Equals(entityId);
        }

        protected override Expression<Func<GoodsPropertyValueEntity, bool>> CreateEntityQueryExpression(IEnumerable<Guid> entityIds)
        {
            return s => entityIds.Contains(s.GoodsId);
        }

        protected override IEnumerable<IGrouping<Guid, GoodsPropertyValueModel>> GroupValues(IEnumerable<GoodsPropertyValueModel> values)
        {
            return values.GroupBy(s => s.GoodsId);
        }

        protected override IQueryable<GoodsPropertyValueModel> JoinProperty(IQueryable<GoodsPropertyValueEntity> values, IQueryable<GoodsPropertyEntity> properties)
        {
            var query = from value in values
                        join property in properties on value.PropertyId equals property.Id
                        select new GoodsPropertyValueModel
                        {
                            CreateTime = value.CreateTime,
                            SubscriberId = value.SubscriberId,
                            GoodsId = value.GoodsId,
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
