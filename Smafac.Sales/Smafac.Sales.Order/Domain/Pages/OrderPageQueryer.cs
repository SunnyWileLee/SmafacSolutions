using Smafac.Framework.Core.Domain.Pages;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.Query;
using Smafac.Sales.Order.Models;
using Smafac.Sales.Order.Repositories.Charge;
using Smafac.Sales.Order.Repositories.ChargeValue;
using Smafac.Sales.Order.Repositories.Pages;
using Smafac.Sales.Order.Repositories.Property;
using Smafac.Sales.Order.Repositories.PropertyValue;
using System.Collections.Generic;
using System.Linq;

namespace Smafac.Sales.Order.Domain.Pages
{
    class OrderPageQueryer : PageQueryer<OrderEntity, OrderModel, OrderPageQueryModel, OrderPropertyValueModel, OrderPropertyEntity>
                           , IOrderPageQueryer
    {
        private readonly IOrderChargeSearchRepository _orderChargeSearchRepository;
        private readonly IOrderChargeValueSearchRepository _orderChargeValueSearchRepository;

        public OrderPageQueryer(IQueryExpressionCreaterProvider queryExpressionCreaterProvider,
                                IOrderPageQueryRepository pageQueryRepository,
                                IOrderPropertyValueSearchRepository propertyValueSearchRepository,
                                IOrderPropertySearchRepository propertySearchRepository,
                                IOrderChargeSearchRepository orderChargeSearchRepository,
                                IOrderChargeValueSearchRepository orderChargeValueSearchRepository
                                    )
        {
            base.QueryExpressionCreaterProvider = queryExpressionCreaterProvider;
            base.PageQueryRepository = pageQueryRepository;
            base.PropertyValueSearchRepository = propertyValueSearchRepository;
            base.PropertySearchRepository = propertySearchRepository;
            _orderChargeSearchRepository = orderChargeSearchRepository;
            _orderChargeValueSearchRepository = orderChargeValueSearchRepository;
        }

        protected override void SetPropertyValues(OrderModel model, IEnumerable<OrderPropertyValueModel> properties)
        {
            model.Properties = base.WrapperPropertyValues(properties);
        }

        protected override void LoadOthers(IEnumerable<OrderModel> models)
        {
            var ids = models.Select(s => s.Id);
            var charges = _orderChargeValueSearchRepository.GetChargeValues(UserContext.Current.SubscriberId, ids);
            models.ToList().ForEach(model =>
            {
                var cs = charges.FirstOrDefault(s => s.Key == model.Id);
                model.Charges = cs == null ? new List<OrderChargeValueModel>() : cs.ToList();
            });
        }

        public OrderPageModel QueryOrderPage(OrderPageQueryModel query)
        {
            var chargeColumns = _orderChargeSearchRepository.SelectTableColumns(UserContext.Current.SubscriberId)
                                    .Select(s => new CustomizedColumnModel { Name = s.Name, Id = s.Id }).ToList();
            var page = new OrderPageModel(base.QueryPage(query))
            {
                ChargeTableColumns = chargeColumns
            };
            return page;
        }
    }
}
