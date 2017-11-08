using Smafac.Pms.Purchase.Applications.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Pms.Purchase.Models;
using Smafac.Framework.Core.Services.Property;
using Smafac.Pms.Purchase.Domain;
using Smafac.Pms.Purchase.Repositories.Property;

namespace Smafac.Pms.Purchase.Services.Property
{
    class PurchasePropertyAddService : PropertyAddService<PurchasePropertyEntity, PurchasePropertyModel>, IPurchasePropertyAddService
    {
        public PurchasePropertyAddService(IPurchasePropertyAddRepository propertyAddRepository,
                                        IPurchasePropertySearchRepository propertySearchRepository)
        {
            base.CustomizedColumnAddRepository = propertyAddRepository;
            base.CustomizedColumnSearchRepository = propertySearchRepository;
        }
    }
}
