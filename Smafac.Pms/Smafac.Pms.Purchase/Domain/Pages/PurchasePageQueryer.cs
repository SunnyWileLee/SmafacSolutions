using Smafac.Framework.Core.Domain.Pages;
using Smafac.Framework.Core.Repositories.Query;
using Smafac.Pms.Purchase.Models;
using Smafac.Pms.Purchase.Repositories;
using Smafac.Pms.Purchase.Repositories.Pages;
using Smafac.Pms.Purchase.Repositories.Property;
using Smafac.Pms.Purchase.Repositories.PropertyValue;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;
using Smafac.Framework.Core.Models;

namespace Smafac.Pms.Purchase.Domain.Pages
{
    class PurchasePageQueryer : PageQueryer<PurchaseEntity, PurchaseModel, PurchasePageQueryModel, PurchasePropertyValueModel, PurchasePropertyEntity>
                           , IPurchasePageQueryer
    {
        public PurchasePageQueryer(IQueryExpressionCreaterProvider queryExpressionCreaterProvider,
                                    IPurchasePageQueryRepository pageQueryRepository,
                                    IPurchasePropertyValueSearchRepository propertyValueSearchRepository,
                                    IPurchasePropertySearchRepository propertySearchRepository,
                                    IPurchaseSearchRepository entitySearchRepository
                                    )
        {
            base.QueryExpressionCreaterProvider = queryExpressionCreaterProvider;
            base.PageQueryRepository = pageQueryRepository;
            base.PropertyValueSearchRepository = propertyValueSearchRepository;
            base.PropertySearchRepository = propertySearchRepository;
            base.EntitySearchRepository = entitySearchRepository;
        }

        protected override List<PurchaseModel> QueryModels(Expression<Func<PurchaseEntity, bool>> predicate)
        {
            var subscriberId = UserContext.Current.SubscriberId;
            var repository = base.EntitySearchRepository as IPurchaseSearchRepository;
            var models = repository.GetPurchase(subscriberId, predicate);
            return models;
        }

        protected override void SetPropertyValues(PurchaseModel model, IEnumerable<PurchasePropertyValueModel> properties)
        {
            model.Properties = base.WrapperPropertyValues(properties);
        }
    }
}
