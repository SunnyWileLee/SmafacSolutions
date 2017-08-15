using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Repositories
{
    interface ICustomerPayTypeRepository
    {
        bool AddPayType(CustomerPayTypeEntity type);
        bool UpdatePayType(CustomerPayTypeEntity type);
        bool DeletePayType(Guid SubscriberId, Guid typeId);
        List<CustomerPayTypeEntity> GetPayTypes(Guid SubscriberId);
        List<CustomerPayTypeModel> GetPayTypeModels(Guid SubscriberId);
    }
}
