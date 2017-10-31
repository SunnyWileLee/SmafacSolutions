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
    class PurchasePropertySearchService : PropertySearchService<PurchasePropertyEntity, PurchasePropertyModel>, IPurchasePropertySearchService
    {
        private readonly IPurchasePropertyProvider _goodsPropertyProvider;

        public PurchasePropertySearchService(IPurchasePropertySearchRepository goodsSearchRepository,
            IPurchasePropertyProvider goodsPropertyProvider)
        {
            base.CustomizedColumnSearchRepository = goodsSearchRepository;
            _goodsPropertyProvider = goodsPropertyProvider;
        }

        public override List<PurchasePropertyModel> GetColumns(Guid entityId)
        {
            return _goodsPropertyProvider.Provide(entityId);
        }
    }
}
