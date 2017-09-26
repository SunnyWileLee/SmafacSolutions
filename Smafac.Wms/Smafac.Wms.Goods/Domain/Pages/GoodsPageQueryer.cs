using Smafac.Framework.Core.Domain.Pages;
using Smafac.Framework.Core.Repositories.Query;
using Smafac.Wms.Goods.Models;
using Smafac.Wms.Goods.Repositories;
using Smafac.Wms.Goods.Repositories.Pages;
using Smafac.Wms.Goods.Repositories.Property;
using Smafac.Wms.Goods.Repositories.PropertyValue;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;
using Smafac.Framework.Core.Models;

namespace Smafac.Wms.Goods.Domain.Pages
{
    class GoodsPageQueryer : PageQueryer<GoodsEntity, GoodsModel, GoodsPageQueryModel, GoodsPropertyValueModel, GoodsPropertyEntity>
                           , IGoodsPageQueryer
    {
        public GoodsPageQueryer(IQueryExpressionCreaterProvider queryExpressionCreaterProvider,
                                    IGoodsPageQueryRepository pageQueryRepository,
                                    IGoodsPropertyValueSearchRepository propertyValueSearchRepository,
                                    IGoodsPropertySearchRepository propertySearchRepository,
                                    IGoodsSearchRepository entitySearchRepository
                                    )
        {
            base.QueryExpressionCreaterProvider = queryExpressionCreaterProvider;
            base.PageQueryRepository = pageQueryRepository;
            base.PropertyValueSearchRepository = propertyValueSearchRepository;
            base.PropertySearchRepository = propertySearchRepository;
            base.EntitySearchRepository = entitySearchRepository;
        }

        protected override List<GoodsModel> QueryModels(Expression<Func<GoodsEntity, bool>> predicate)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var repository = base.EntitySearchRepository as IGoodsSearchRepository;
            var models = repository.GetGoods(subscriberId, predicate);
            return models;
        }

        protected override void SetPropertyValues(GoodsModel model, IEnumerable<GoodsPropertyValueModel> properties)
        {
            model.Properties = base.WrapperPropertyValues(properties);
        }
    }
}
