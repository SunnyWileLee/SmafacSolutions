using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using AutoMapper;
using Smafac.Crm.Customer.Models;
using Smafac.Crm.Customer.Domain;
using Smafac.Framework.Core.Repositories.Pages;

namespace Smafac.Crm.Customer.Repositories.Pages
{
    class CustomerPageQueryRepository : PageQueryRepository<CustomerContext, CustomerEntity, CustomerModel>
                                        , ICustomerPageQueryRepository
    {
        public CustomerPageQueryRepository(ICustomerContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
