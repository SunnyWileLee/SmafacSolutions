using Smafac.Crm.Customer.Applications;
using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using Smafac.Crm.Customer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Services
{
    class CustomerReceiveService : ICustomerReceiveService
    {
        private readonly ICustomerReceiver _customerReceiver;
        private readonly ICustomerReceiveRepository _customerReceiveRepository;
        public CustomerReceiveService(ICustomerReceiver customerReceiver,
                                    ICustomerReceiveRepository customerReceiveRepository)
        {
            _customerReceiver = customerReceiver;
            _customerReceiveRepository = customerReceiveRepository;
        }

        public bool ReceiveCustomer(CustomerReceiveModel model)
        {
            var Receive = _customerReceiver.Receive(model);
            return _customerReceiveRepository.AddReceive(Receive);
        }
    }
}
