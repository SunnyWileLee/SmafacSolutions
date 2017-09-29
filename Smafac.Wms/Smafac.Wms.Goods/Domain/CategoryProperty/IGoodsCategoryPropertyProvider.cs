using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Domain.EntityAssociationProviders;
using Smafac.Framework.Core.Models;
using Smafac.Wms.Goods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Domain.CategoryProperty
{
    interface IGoodsCategoryPropertyProvider:IEntityAssociationProvider<GoodsPropertyModel>
    {
        
    }
}
