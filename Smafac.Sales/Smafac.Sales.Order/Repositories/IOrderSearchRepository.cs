﻿using Smafac.Framework.Core.Repositories;
using Smafac.Sales.Order.Domain;
using Smafac.Sales.Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Sales.Order.Repositories
{
    interface IOrderSearchRepository : IEntitySearchRepository<OrderEntity>
    {

    }
}
