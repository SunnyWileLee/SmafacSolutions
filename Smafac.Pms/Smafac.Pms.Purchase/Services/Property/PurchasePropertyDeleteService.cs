using Smafac.Framework.Core.Services.Property;
using Smafac.Pms.Purchase.Applications.Property;
using Smafac.Pms.Purchase.Domain;
using Smafac.Pms.Purchase.Domain.Property;
using Smafac.Pms.Purchase.Models;
using Smafac.Pms.Purchase.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Services.Property
{
    class PurchasePropertyDeleteService : PropertyDeleteService<PurchasePropertyEntity, PurchasePropertyModel>, IPurchasePropertyDeleteService
    {
        public PurchasePropertyDeleteService(IPurchasePropertyDeleteRepository goodsPropertyDeleteRepository,
                                          IPurchasePropertySearchRepository goodsPropertySearchRepository,
                                          IPurchasePropertyUsedChecker[] goodsFinancePropertyUsedCheckers,
                                          IPurchasePropertyDeleteTrigger[] goodsPropertyDeleteTriggers)
        {
            base.CustomizedColumnDeleteRepository = goodsPropertyDeleteRepository;
            base.CustomizedColumnUsedCheckers = goodsFinancePropertyUsedCheckers;
            base.CustomizedColumnSearchRepository = goodsPropertySearchRepository;
            base.CustomizedColumnDeleteTriggers = goodsPropertyDeleteTriggers;
        }
    }
}
