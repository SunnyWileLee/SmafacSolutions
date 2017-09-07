using System;
using Smafac.Crm.CustomerFinance.Applications.Propety;
using Smafac.Crm.CustomerFinance.Models;
using Smafac.Framework.Core.Applications.Property;

namespace Smafac.Crm.CustomerFinance.Services.Property
{
    class CustomerFinancePropertyService : ICustomerFinancePropertyService
    {
        public CustomerFinancePropertyService(ICustomerFinancePropertyAddService financePropertyAddService,
            ICustomerFinancePropertyDeleteService financePropertyDeleteService,
            ICustomerFinancePropertySearchService financePropertySearchService,
            ICustomerFinancePropertyUpdateService financePropertyUpdateService)
        {
            AddService = financePropertyAddService;
            DeleteService = financePropertyDeleteService;
            SearchService = financePropertySearchService;
            UpdateService = financePropertyUpdateService;
        }

        public ICustomerFinancePropertyAddService AddService { get ; set; }
        public ICustomerFinancePropertyDeleteService DeleteService { get; set; }
        public ICustomerFinancePropertySearchService SearchService { get; set; }
        public ICustomerFinancePropertyUpdateService UpdateService { get; set; }
    }
}
