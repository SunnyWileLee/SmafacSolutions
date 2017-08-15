using Smafac.Crm.Customer.Models;
using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Smafac.Crm.Customer.Domain
{
    class CustomerVisitor : ICustomerVisitor
    {
        public CustomerVisitEntity Visit(CustomerVisitModel model)
        {
            var userContext = UserContext.Current;
            var visit = Mapper.Map<CustomerVisitEntity>(model);
            visit.SubscriberId = userContext.SubscriberId;
            visit.InvokerId = userContext.UserId;
            return visit;
        }
    }
}
