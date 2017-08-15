using Smafac.Crm.Customer.Applications;
using Smafac.Crm.Customer.Models;
using Smafac.Crm.Customer.Repositories;
using Smafac.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Services
{
    class CustomerSearchService : ICustomerSearchService
    {
        private readonly ICustomerSearchRepository _customerSearchRepository;

        public CustomerSearchService(ICustomerSearchRepository customerSearchRepository)
        {
            _customerSearchRepository = customerSearchRepository;
        }
        public CustomerDetailModel GetCustomerDetail(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public PageModel<CustomerModel> GetCustomerPage(CustomerPageQueryModel query)
        {
            var customers = _customerSearchRepository.GetCustomerPage(query);
            var count = _customerSearchRepository.GetCustomerCount(query);
            return new PageModel<CustomerModel>
            {
                PageData = customers,
                PageSize = query.PageSize,
                PageIndex = query.PageIndex,
                TotalCount = count
            };
        }
    }
}
