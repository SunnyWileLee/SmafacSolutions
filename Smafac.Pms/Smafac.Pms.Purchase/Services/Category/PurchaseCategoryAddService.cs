using Smafac.Pms.Purchase.Applications.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Pms.Purchase.Models;
using Smafac.Framework.Core.Services.Category;
using Smafac.Pms.Purchase.Domain;
using Smafac.Pms.Purchase.Repositories.Category;

namespace Smafac.Pms.Purchase.Services.Category
{
    class PurchaseCategoryAddService : CategoryAddService<PurchaseCategoryEntity, PurchaseCategoryModel>, IPurchaseCategoryAddService
    {
        public PurchaseCategoryAddService(IPurchaseCategoryAddRepository goodsCategoryAddRepository,
                                        IPurchaseCategorySearchRepository goodsCategorySearchRepository)
        {
            base.CategoryAddRepository = goodsCategoryAddRepository;
            base.CategorySearchRepository = goodsCategorySearchRepository;
        }
    }
}
