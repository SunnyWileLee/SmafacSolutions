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
        public PurchaseCategoryPropertyBindService(IPurchaseCategoryPropertyBindRepository categoryPropertyBindRepository,
                                                IPurchaseCategoryPropertySearchRepository categoryPropertySearchRepository,
                                                IEnumerable<IPurchaseCategoryPropertyBindTrigger> categoryPropertyBindTriggers,
                                                IPurchaseCategorySearchRepository categorySearchRepository,
                                                IPurchasePropertySearchRepository propertySearchRepository
                                                )
        {
            base.EntityAssociationBindRepository = categoryPropertyBindRepository;
            base.EntityAssociationSearchRepository = categoryPropertySearchRepository;
            base.CategoryAssociationBindTriggers = categoryPropertyBindTriggers;
            base.CategorySearchRepository = categorySearchRepository;
            base.AssociationSearchRepository = propertySearchRepository;
        }
    }
}
