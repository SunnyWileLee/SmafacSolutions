﻿using Smafac.Framework.Core.Services.CustomizedColumn;
using Smafac.Sales.Order.Applications.Charge;
using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Models;
using Smafac.Sales.Order.Repositories.Charge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Services.Charge
{
    class OrderChargeUpdateService : CustomizedColumnUpdateService<OrderChargeEntity, OrderChargeModel>,
                                    IOrderChargeUpdateService
    {
        public OrderChargeUpdateService(IOrderChargeUpdateRepository orderChargeUpdateRepository,
                                        IOrderChargeSearchRepository orderChargeSearchRepository)
        {
            base.CustomizedColumnUpdateRepository = orderChargeUpdateRepository;
            base.CustomizedColumnSearchRepository = orderChargeSearchRepository;
        }
    }
}
