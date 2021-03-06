﻿using Smafac.Framework.Core.Applications.Property;
using Smafac.Pms.Purchase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Pms.Purchase.Applications.Property
{
    public interface IPurchasePropertyService 
    {
        IPurchasePropertyAddService AddService { get; set; }
        IPurchasePropertyDeleteService DeleteService { get; set; }
        IPurchasePropertySearchService SearchService { get; set; }
        IPurchasePropertyUpdateService UpdateService { get; set; }
    }
}
