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
    class CustomerVisitService : ICustomerVisitService
    {
        private readonly ICustomerVisitor _customerVisitor;
        private readonly ICustomerVisitRepository _customerVisitRepository;
        public CustomerVisitService(ICustomerVisitor customerVisitor,
                                    ICustomerVisitRepository customerVisitRepository)
        {
            _customerVisitor = customerVisitor;
            _customerVisitRepository = customerVisitRepository;
        }

        public bool VisitCustomer(CustomerVisitModel model)
        {
            var visit = _customerVisitor.Visit(model);
            return _customerVisitRepository.AddVisit(visit);
        }
    }
}
