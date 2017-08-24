using Smafac.Framework.Models;
using Smafac.Wms.Goods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Domain
{
    interface IGoodsCategoryPropertyProvider
    {
        List<GoodsPropertyModel> Provide(Guid categoryId);
    }
}
