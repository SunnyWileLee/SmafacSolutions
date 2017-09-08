using Smafac.Sales.Order.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Sales.Order.Models;
using Smafac.Sales.Order.Repositories;
using AutoMapper;
using Smafac.Sales.Order.Domain;
using Smafac.Framework.Core.Models;
using Smafac.Sales.Order.Applications.Charge;
using Smafac.Sales.Order.Repositories.Charge;
using Smafac.Sales.Order.Repositories.ChargeValue;

namespace Smafac.Sales.Order.Services.Charge
{
    class OrderChargeService : IOrderChargeService
    {
        public OrderChargeService(IOrderChargeDeleteService orderChargeDeleteService,
                                IOrderChargeAddService orderChargeAddService,
                                IOrderChargeUpdateService orderChargeUpdateService
                                 )
        {
            DeleteService = orderChargeDeleteService;
            AddService = orderChargeAddService;
            UpdateService = orderChargeUpdateService;
        }

        public IOrderChargeDeleteService DeleteService { get; set; }
        public IOrderChargeAddService AddService { get; set; }
        public IOrderChargeUpdateService UpdateService { get; set; }
    }
}
