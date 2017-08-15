using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Applications
{
    public interface ICustomerContactSearchService
    {
        List<CustomerContactModel> GetContacts(Guid customerId);
        CustomerContactDetailModel GetContactDetail(Guid contactId);
    }
}
