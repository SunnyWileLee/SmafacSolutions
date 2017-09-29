using Smafac.Framework.Core.Domain.Pages;
using Smafac.Framework.Core.Models;
using Smafac.Framework.Core.Repositories.Query;
using Smafac.Framework.Core.Models;
using Smafac.Sales.DeliveryNote.Models;
using Smafac.Sales.DeliveryNote.Repositories.Pages;
using Smafac.Sales.DeliveryNote.Repositories.Property;
using Smafac.Sales.DeliveryNote.Repositories.PropertyValue;
using System.Collections.Generic;
using System.Linq;

namespace Smafac.Sales.DeliveryNote.Domain.Pages
{
    class DeliveryNotePageQueryer : PageQueryer<DeliveryNoteEntity, DeliveryNoteModel, DeliveryNotePageQueryModel, DeliveryNotePropertyValueModel, DeliveryNotePropertyEntity>
                           , IDeliveryNotePageQueryer
    {
        public DeliveryNotePageQueryer(IQueryExpressionCreaterProvider queryExpressionCreaterProvider,
                                    IDeliveryNotePageQueryRepository pageQueryRepository,
                                    IDeliveryNotePropertyValueSearchRepository propertyValueSearchRepository,
                                    IDeliveryNotePropertySearchRepository propertySearchRepository
                                    )
        {
            base.QueryExpressionCreaterProvider = queryExpressionCreaterProvider;
            base.PageQueryRepository = pageQueryRepository;
            base.PropertyValueSearchRepository = propertyValueSearchRepository;
            base.PropertySearchRepository = propertySearchRepository;
        }

        protected override void SetPropertyValues(DeliveryNoteModel model, IEnumerable<DeliveryNotePropertyValueModel> properties)
        {
            model.Properties = base.WrapperPropertyValues(properties);
        }
    }
}
