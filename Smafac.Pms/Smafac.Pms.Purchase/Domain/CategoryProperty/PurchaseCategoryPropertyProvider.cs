using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Core.Models;
using Smafac.Pms.Purchase.Repositories;
using Smafac.Framework.Core.Models;
using AutoMapper;
using Smafac.Pms.Purchase.Models;
using Smafac.Framework.Core.Domain;
using Smafac.Pms.Purchase.Repositories.Category;
using Smafac.Pms.Purchase.Repositories.CategoryProperty;
using Smafac.Framework.Core.Domain.EntityAssociationProviders;

namespace Smafac.Pms.Purchase.Domain.CategoryProperty
{
    class PurchaseCategoryPropertyProvider : CategoryPropertyProvider<PurchaseCategoryEntity, PurchasePropertyEntity, PurchasePropertyModel>,
                                            IPurchaseCategoryPropertyProvider
    {

        public PurchaseCategoryPropertyProvider(IPurchaseCategoryPropertySearchRepository goodsCategoryPropertySearchRepository,
                                            IPurchaseCategorySearchRepository goodsCategorySearchRepository)
        {
            base.CategorySearchRepository = goodsCategorySearchRepository;
            base.CategoryAssociationSearchRepository = goodsCategoryPropertySearchRepository;
        }
    }
}
