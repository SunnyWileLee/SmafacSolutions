using Smafac.Framework.Core.Domain.Pages;
using Smafac.Framework.Core.Repositories.Query;
using Smafac.Wms.Goods.Models;
using Smafac.Wms.Goods.Repositories.Pages;
using Smafac.Wms.Goods.Repositories.Property;
using Smafac.Wms.Goods.Repositories.PropertyValue;
using System.Collections.Generic;
using System.Linq;

namespace Smafac.Wms.Goods.Domain.Pages
{
    class GoodsPageQueryer : PageQueryer<GoodsEntity, GoodsModel, GoodsPageQueryModel, GoodsPropertyValueModel, GoodsPropertyEntity>
                           ,IGoodsPageQueryer
    {
        public GoodsPageQueryer(IQueryExpressionCreaterProvider queryExpressionCreaterProvider,
                                    IGoodsPageQueryRepository pageQueryRepository,
                                    IGoodsPropertyValueSearchRepository propertyValueSearchRepository,
                                    IGoodsPropertySearchRepository propertySearchRepository
                                    )
        {
            base.QueryExpressionCreaterProvider = queryExpressionCreaterProvider;
            base.PageQueryRepository = pageQueryRepository;
            base.PropertyValueSearchRepository = propertyValueSearchRepository;
            base.PropertySearchRepository = propertySearchRepository;
        }

        protected override void SetPropertyValues(GoodsModel model, IEnumerable<GoodsPropertyValueModel> properties)
        {
            model.Properties = base.WrapperPropertyValues(properties);
        }
    }
}
