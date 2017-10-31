using Smafac.Framework.Core.Services.Category;
using Smafac.Pms.Purchase.Applications.Category;
using Smafac.Pms.Purchase.Domain;
using Smafac.Pms.Purchase.Domain.Property;
using Smafac.Pms.Purchase.Models;
using Smafac.Pms.Purchase.Repositories.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Services.Category
{
    class PurchaseCategorySearchService : CategorySearchService<PurchaseCategoryEntity, PurchaseCategoryModel>, IPurchaseCategorySearchService
    {
        public PurchaseCategorySearchService(IPurchaseCategorySearchRepository goodsSearchRepository,
            IPurchasePropertyProvider goodsCategoryProvider)
        {
            base.CategorySearchRepository = goodsSearchRepository;
        }
    }
}
