using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Domain
{
    interface ICustomerReceiver
    {
        CustomerReceiveEntity Receive(CustomerReceiveModel model);
    }
}
