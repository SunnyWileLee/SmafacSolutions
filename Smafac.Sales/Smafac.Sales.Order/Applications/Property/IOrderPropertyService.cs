using Smafac.Framework.Core.Applications.Property;
using Smafac.Sales.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Applications.Property
{
    public interface IOrderPropertyService 
    {
        IOrderPropertyAddService AddService { get; set; }
        IOrderPropertyDeleteService DeleteService { get; set; }
        IOrderPropertySearchService SearchService { get; set; }
        IOrderPropertyUpdateService UpdateService { get; set; }
    }
}
