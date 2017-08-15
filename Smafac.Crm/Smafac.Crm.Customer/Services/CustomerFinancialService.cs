using Smafac.Crm.Customer.Applications;
using Smafac.Crm.Customer.Models;
using Smafac.Crm.Customer.Repositories;
using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Services
{
    class CustomerFinancialService : ICustomerFinancialService
    {
        private readonly ICustomerFinancialRepository _customerFinancialRepository;
        private readonly ICustomerSearchRepository _customerSearchRepository;

        public CustomerFinancialService(ICustomerFinancialRepository customerFinancialRepository,
                                        ICustomerSearchRepository customerSearchRepository)
        {
            _customerFinancialRepository = customerFinancialRepository;
            _customerSearchRepository = customerSearchRepository;
        }

        public bool CustomerPay(CustomerFinancialModel model)
        {
            var SubscriberId = UserContext.Current.SubscriberId;
            var customer = _customerSearchRepository.GetById(SubscriberId, model.CustomerId);
            var financial = customer.Pay(model);
            return _customerFinancialRepository.AddFinancial(financial);
        }
    }
}
