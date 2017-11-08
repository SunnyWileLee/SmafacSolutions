using Smafac.Pms.Purchase.Applications;
using Smafac.Pms.Purchase.Models;
using Smafac.Pms.Purchase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Smafac.Pms.Purchase.Domain;
using Smafac.Framework.Core.Models;
using Smafac.Pms.Purchase.Repositories.PropertyValue;

namespace Smafac.Pms.Purchase.Services
{
    class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseAddRepository _goodsRepository;
        private readonly IPurchasePropertyValueSetRepository _propertyValueSetRepository;

        public PurchaseService(IPurchaseAddRepository goodsRepository,
                            IPurchaseUpdateService updateService,
                            IPurchasePropertyValueSetRepository propertyValueSetRepository
                            )
        {
            _goodsRepository = goodsRepository;
            _propertyValueSetRepository = propertyValueSetRepository;
            UpdateService = updateService;
        }

        public IPurchaseUpdateService UpdateService { get; set; }

        public bool AddPurchase(PurchaseModel model)
        {
            var goods = Mapper.Map<PurchaseEntity>(model);
            goods.SubscriberId = UserContext.Current.SubscriberId;
            var add = _goodsRepository.AddEntity(goods);

            if (add && model.HasProperties)
            {
                model.Properties.ForEach(property =>
                {
                    property.PurchaseId = goods.Id;
                    property.SubscriberId = goods.SubscriberId;
                });
                var values = Mapper.Map<List<PurchasePropertyValueEntity>>(model.Properties);
                return _propertyValueSetRepository.AddPropertyValues(goods.Id, values);
            }
            return add;
        }

        public PurchaseModel CreateEmptyPurchase()
        {
            return new PurchaseModel();
        }
    }
}
