using Smafac.Framework.Core.Applications.Property;
using Smafac.Wms.Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Stock.Applications.Property
{
    public interface IStockPropertyService 
    {
        IStockPropertyAddService AddService { get; set; }
        IStockPropertyDeleteService DeleteService { get; set; }
        IStockPropertySearchService SearchService { get; set; }
        IStockPropertyUpdateService UpdateService { get; set; }
    }
}
