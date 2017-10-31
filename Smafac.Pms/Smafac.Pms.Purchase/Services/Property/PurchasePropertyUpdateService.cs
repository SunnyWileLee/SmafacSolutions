using Smafac.Framework.Core.Services.Property;
using Smafac.Pms.Purchase.Applications.Property;
using Smafac.Pms.Purchase.Domain;
using Smafac.Pms.Purchase.Models;
using Smafac.Pms.Purchase.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Services.Property
{
    class PurchasePropertyUpdateService : PropertyUpdateService<PurchasePropertyEntity, PurchasePropertyModel>, IPurchasePropertyUpdateService
    {
        public PurchasePropertyUpdateService(IPurchasePropertySearchRepository goodsPropertySearchRepository,
                                          IPurchasePropertyUpdateRepository goodsPropertyUpdateRepository)
        {
            base.CustomizedColumnSearchRepository = goodsPropertySearchRepository;
            base.CustomizedColumnUpdateRepository = goodsPropertyUpdateRepository;
        }
    }
}
