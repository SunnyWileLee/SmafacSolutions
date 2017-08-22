﻿using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Applications
{
    public interface IGoodsCategoryPropertyService
    {
        List<PropertyModel> GetProperties(Guid categoryId);
    }
}
