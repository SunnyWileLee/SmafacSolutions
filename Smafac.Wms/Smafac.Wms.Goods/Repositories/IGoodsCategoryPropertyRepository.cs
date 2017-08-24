using Smafac.Wms.Goods.Domain;
using Smafac.Wms.Goods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Repositories
{
    interface IGoodsCategoryPropertyRepository
    {
        bool BindProperties(Guid subscriberId, Guid categoryId, IEnumerable<Guid> propertyIds);
        bool UnbindProperties(Guid subscriberId, Guid categoryId);
        bool IsBound(Guid subscriberId, Guid categoryId);
        List<GoodsPropertyEntity> GetProperties(Guid subscriberId, Guid categoryId);
    }
}
