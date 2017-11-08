using Smafac.Framework.Core.Services.CategoryProperty;
using Smafac.Pms.Purchase.Applications.CategoryProperty;
using Smafac.Pms.Purchase.Domain;
using Smafac.Pms.Purchase.Domain.CategoryProperty;
using Smafac.Pms.Purchase.Models;
using Smafac.Pms.Purchase.Repositories.CategoryProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Services.CategoryProperty
{
    class PurchaseCategoryPropertySearchService : CategoryPropertySearchService<PurchaseCategoryEntity, PurchasePropertyEntity, PurchasePropertyModel>,
                                                IPurchaseCategoryPropertySearchService
    {
        public PurchaseCategoryPropertySearchService(IPurchaseCategoryPropertySearchRepository categoryPropertySearchRepository,
            IPurchaseCategoryPropertyProvider categoryPropertyProvider
            )
        {
            base.CategoryAssociationProvider = categoryPropertyProvider;
            base.EntityAssociationSearchRepository = categoryPropertySearchRepository;
        }
    }
}
