using AutoMapper;
using Smafac.Crm.Customer.Models;
using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Domain
{
    class CustomerReceiver : ICustomerReceiver
    {
        public CustomerReceiveEntity Receive(CustomerReceiveModel model)
        {
            var userContext = UserContext.Current;
            var visit = Mapper.Map<CustomerReceiveEntity>(model);
            visit.SubscriberId = userContext.SubscriberId;
            visit.InvokerId = userContext.UserId;
            return visit;
        }
    }
}
