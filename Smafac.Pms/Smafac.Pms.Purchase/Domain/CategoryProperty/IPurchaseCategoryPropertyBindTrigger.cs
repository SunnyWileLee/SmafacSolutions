﻿using Smafac.Framework.Core.Domain.CategoryProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Domain.CategoryProperty
{
    interface IPurchaseCategoryPropertyBindTrigger: ICategoryPropertyBindTrigger<PurchaseCategoryEntity, PurchasePropertyEntity>
    {
    }
}
