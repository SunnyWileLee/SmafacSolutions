using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Applications
{
    public interface ICustomerPayTypeService
    {
        bool AddPayType(CustomerPayTypeModel model);
        bool UpdatePayType(CustomerPayTypeModel model);
        bool DeletePayType(Guid payTypeId);
        List<CustomerPayTypeModel> GetPayTypes();
    }
}
