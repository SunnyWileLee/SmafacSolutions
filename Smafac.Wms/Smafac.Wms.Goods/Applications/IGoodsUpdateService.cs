﻿using Smafac.Wms.Goods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Applications
{
    public interface IGoodsUpdateService
    {
        bool UpdateGoods(GoodsModel model);
    }
}
