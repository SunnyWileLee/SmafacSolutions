﻿using Smafac.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Applications
{
    public interface ICustomerContactService
    {
        bool AddContact(CustomerContactModel model);
        bool UpdateContact(CustomerContactModel model);
        bool DeleteContact(Guid contactId);
    }
}
