﻿using Smafac.Wms.Stock.Applications.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Core.Applications.Property;
using Smafac.Wms.Stock.Models;

namespace Smafac.Wms.Stock.Services.Property
{
    class StockPropertyService : IStockPropertyService
    {
        public StockPropertyService(IStockPropertyAddService propertyAddService,
            IStockPropertyDeleteService propertyDeleteService,
            IStockPropertySearchService propertySearchService,
            IStockPropertyUpdateService propertyUpdateService)
        {
            AddService = propertyAddService;
            DeleteService = propertyDeleteService;
            SearchService = propertySearchService;
            UpdateService = propertyUpdateService;
        }

        public IStockPropertyAddService AddService { get; set; }
        public IStockPropertyDeleteService DeleteService { get; set; }
        public IStockPropertySearchService SearchService { get; set; }
        public IStockPropertyUpdateService UpdateService { get; set; }
    }
}
