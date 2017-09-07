using System;
using Smafac.Crm.Customer.Applications.Propety;
using Smafac.Crm.Customer.Models;
using Smafac.Framework.Core.Applications.CustomizedColumn;
using Smafac.Framework.Core.Applications.Property;

namespace Smafac.Crm.Customer.Services.Property
{
    class CustomerPropertyService : ICustomerPropertyService
    {
        public CustomerPropertyService(ICustomerPropertyAddService customerPropertyAddService,
            ICustomerPropertyDeleteService customerPropertyDeleteService,
            ICustomerPropertySearchService customerPropertySearchService,
            ICustomerPropertyUpdateService customerPropertyUpdateService)
        {
            AddService = customerPropertyAddService;
            DeleteService = customerPropertyDeleteService;
            SearchService = customerPropertySearchService;
            UpdateService = customerPropertyUpdateService;
        }

        public ICustomerPropertyAddService AddService { get; set; }
        public ICustomerPropertyDeleteService DeleteService { get; set; }
        public ICustomerPropertySearchService SearchService { get; set; }
        public ICustomerPropertyUpdateService UpdateService { get; set; }
    }
}
