using Smafac.Framework.Core.Applications.Property;
using Smafac.Wms.Goods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Wms.Goods.Applications.Property
{
    public interface IGoodsPropertyService 
    {
        IGoodsPropertyAddService AddService { get; set; }
        IGoodsPropertyDeleteService DeleteService { get; set; }
        IGoodsPropertySearchService SearchService { get; set; }
        IGoodsPropertyUpdateService UpdateService { get; set; }
    }
}
