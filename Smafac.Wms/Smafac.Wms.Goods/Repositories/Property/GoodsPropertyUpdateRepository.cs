﻿using Smafac.Framework.Core.Repositories.Property;
using Smafac.Wms.Goods.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Repositories.Property
{
    class GoodsPropertyUpdateRepository : PropertyUpdateRepository<GoodsContext, GoodsPropertyEntity>, IGoodsPropertyUpdateRepository
    {
        public GoodsPropertyUpdateRepository(IGoodsContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
