using Smafac.Pms.Purchase.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Pms.Purchase.Models;
using Smafac.Pms.Purchase.Repositories;
using AutoMapper;
using Smafac.Pms.Purchase.Domain;
using Smafac.Framework.Core.Models;
using Smafac.Pms.Purchase.Repositories.PropertyValue;

namespace Smafac.Pms.Purchase.Services
{
    class PurchaseUpdateService : IPurchaseUpdateService
    {
        private readonly IPurchaseUpdateRepository _goodsUpdateRepository;
        private readonly IPurchasePropertyValueSetRepository _propertyValueSetRepository;

        public PurchaseUpdateService(IPurchaseUpdateRepository goodsUpdateRepository,
                                    IPurchasePropertyValueSetRepository propertyValueSetRepository)
        {
            _goodsUpdateRepository = goodsUpdateRepository;
            _propertyValueSetRepository = propertyValueSetRepository;
        }

        public bool UpdatePurchase(PurchaseModel model)
        {
            var goods = Mapper.Map<PurchaseEntity>(model);
            goods.SubscriberId = UserContext.Current.SubscriberId;
            var update = _goodsUpdateRepository.UpdateEntity(goods);

            if (update && model.HasProperties)
            {
                model.Properties.ForEach(property =>
                {
                    property.PurchaseId = goods.Id;
                    property.SubscriberId = goods.SubscriberId;
                    var value = Mapper.Map<PurchasePropertyValueEntity>(property);
                    update &= _propertyValueSetRepository.SetPropertyValue(value);
                });
            }
            return update;
        }
    }
}
