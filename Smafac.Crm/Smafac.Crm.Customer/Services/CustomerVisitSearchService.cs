using Smafac.Crm.Customer.Applications;
using Smafac.Crm.Customer.Domain;
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
    class CustomerVisitSearchService : ICustomerVisitSearchService
    {
        private readonly ICustomerVisitSearchRepository _customerVisitSearchRepository;

        public CustomerVisitSearchService(ICustomerVisitSearchRepository customerVisitSearchRepository)
        {
            _customerVisitSearchRepository = customerVisitSearchRepository;
        }
        public PageModel<CustomerVisitModel> GetVisitPage(CustomerVisitPageQueryModel query)
        {
            var predicate = query.CreatePredicate<CustomerVisitEntity>();
            var visits = _customerVisitSearchRepository.GetVisits(predicate, query.Skip, query.PageSize);
            var count = _customerVisitSearchRepository.GetVisitCount(predicate);
            return new PageModel<CustomerVisitModel>
            {
                PageData = visits,
                PageSize = query.PageSize,
                PageIndex = query.PageIndex,
                TotalCount = count
            };
        }
    }
}
