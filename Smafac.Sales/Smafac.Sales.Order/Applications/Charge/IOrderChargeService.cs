using Smafac.Sales.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Applications.Charge
{
    public interface IOrderChargeService
    {
        IOrderChargeAddService AddService { get; set; }
        IOrderChargeUpdateService UpdateService { get; set; }
        IOrderChargeDeleteService DeleteService { get; set; }
    }
}
