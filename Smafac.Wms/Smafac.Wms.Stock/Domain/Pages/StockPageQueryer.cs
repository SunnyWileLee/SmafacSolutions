using Smafac.Framework.Core.Domain.Pages;
using Smafac.Framework.Core.Repositories.Query;
using Smafac.Wms.Stock.Models;
using Smafac.Wms.Stock.Repositories;
using Smafac.Wms.Stock.Repositories.Pages;
using Smafac.Wms.Stock.Repositories.Property;
using Smafac.Wms.Stock.Repositories.PropertyValue;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;
using Smafac.Framework.Core.Models;

namespace Smafac.Wms.Stock.Domain.Pages
{
    class StockPageQueryer : PageQueryer<StockEntity, StockModel, StockPageQueryModel, StockPropertyValueModel, StockPropertyEntity>
                           , IStockPageQueryer
    {
        public StockPageQueryer(IQueryExpressionCreaterProvider queryExpressionCreaterProvider,
                                    IStockPageQueryRepository pageQueryRepository,
                                    IStockPropertyValueSearchRepository propertyValueSearchRepository,
                                    IStockPropertySearchRepository propertySearchRepository,
                                    IStockSearchRepository entitySearchRepository
                                    )
        {
            base.QueryExpressionCreaterProvider = queryExpressionCreaterProvider;
            base.PageQueryRepository = pageQueryRepository;
            base.PropertyValueSearchRepository = propertyValueSearchRepository;
            base.PropertySearchRepository = propertySearchRepository;
            base.EntitySearchRepository = entitySearchRepository;
        }

        protected override List<StockModel> QueryModels(Expression<Func<StockEntity, bool>> predicate)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var repository = base.EntitySearchRepository as IStockSearchRepository;
            var models = repository.GetStock(subscriberId, predicate);
            return models;
        }

        protected override void SetPropertyValues(StockModel model, IEnumerable<StockPropertyValueModel> properties)
        {
            model.Properties = base.WrapperPropertyValues(properties);
        }
    }
}
