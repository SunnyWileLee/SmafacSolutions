using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Framework.Core.Services.CategoryProperty;
using Smafac.Pms.Purchase.Applications.CategoryProperty;
using Smafac.Pms.Purchase.Domain;
using Smafac.Pms.Purchase.Domain.CategoryProperty;
using Smafac.Pms.Purchase.Repositories.Category;
using Smafac.Pms.Purchase.Repositories.CategoryProperty;
using Smafac.Pms.Purchase.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Services.CategoryProperty
{
    class PurchaseCategoryPropertyBindService : CategoryPropertyBindService<PurchaseCategoryEntity, PurchasePropertyEntity>,
                                        IPurchaseCategoryPropertyBindService
    {
        public PurchaseCategoryPropertyBindService(IPurchaseCategoryPropertyBindRepository goodsCategoryPropertyBindRepository,
                                                IPurchaseCategoryPropertySearchRepository goodsCategoryPropertySearchRepository,
                                                IEnumerable<IPurchaseCategoryPropertyBindTrigger> goodsCategoryPropertyBindTriggers,
                                                IPurchaseCategorySearchRepository goodsCategorySearchRepository,
                                                IPurchasePropertySearchRepository goodsPropertySearchRepository
                                                )
        {
            base.EntityAssociationBindRepository = goodsCategoryPropertyBindRepository;
            base.EntityAssociationSearchRepository = goodsCategoryPropertySearchRepository;
            base.CategoryAssociationBindTriggers = goodsCategoryPropertyBindTriggers;
            base.CategorySearchRepository = goodsCategorySearchRepository;
            base.AssociationSearchRepository = goodsPropertySearchRepository;
        }
    }
}
