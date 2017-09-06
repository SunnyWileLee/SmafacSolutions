using Smafac.Crm.Customer.Models;
using Smafac.Framework.Core.Domain.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Domain.Pages
{
    interface ICustomerPageQueryer : IPageQueryer<CustomerModel, CustomerPageQueryModel>
    {
    }
}
