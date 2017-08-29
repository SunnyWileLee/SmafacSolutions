using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Wms.Goods.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Repositories.CategoryProperty
{
    interface IGoodsCategoryPropertyBindRepository : ICategoryPropertyBindRepository<GoodsCategoryEntity, GoodsPropertyEntity>
    {
    }
}
