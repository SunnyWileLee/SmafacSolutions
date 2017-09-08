using AutoMapper;
using Newtonsoft.Json;
using Smafac.Crm.CustomerFinance.Applications;
using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Models;
using Smafac.Crm.CustomerFinance.Repositories;
using Smafac.Crm.CustomerFinance.Repositories.Property;
using Smafac.Crm.CustomerFinance.Repositories.PropertyValue;
using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Smafac.Crm.CustomerFinance.Services
{
    class CustomerFinanceService : ICustomerFinanceService
    {
        private readonly ICustomerFinanceRepository _financeRepository;
        private readonly ICustomerFinancePropertyValueSetRepository _financePropertyValueSetRepository;
        private readonly ICustomerFinancePropertySearchRepository _financePropertySearchRepository;

        public ICustomerFinanceUpdateService UpdateService { get; set; }

        public CustomerFinanceService(ICustomerFinanceRepository financeRepository,
                                    ICustomerFinanceUpdateService financeUpdateService,
                            ICustomerFinancePropertyValueSetRepository financePropertyValueSetRepository,
                            ICustomerFinancePropertySearchRepository financePropertySearchRepository)
        {
            _financeRepository = financeRepository;
            _financePropertyValueSetRepository = financePropertyValueSetRepository;
            _financePropertySearchRepository = financePropertySearchRepository;
            UpdateService = financeUpdateService;
        }

        public bool AddCustomerFinance(CustomerFinanceModel model)
        {
            var finance = Mapper.Map<CustomerFinanceEntity>(model);
            finance.SubscriberId = UserContext.Current.SubscriberId;
            if (_financeRepository.AddCustomerFinance(finance))
            {
                if (model.HasProperties)
                {
                    if (!AddPropertyValues(finance, model.Properties))
                    {
                        var properties = JsonConvert.SerializeObject(model.Properties);
                    }
                }
                return true;
            }
            return false;
        }

        private bool AddPropertyValues(CustomerFinanceEntity finance, IEnumerable<CustomerFinancePropertyValueModel> values)
        {
            var properties = Mapper.Map<List<CustomerFinancePropertyValueEntity>>(values);
            properties.ForEach(property =>
            {
                property.CustomerFinanceId = finance.Id;
                property.SubscriberId = finance.SubscriberId;
            });
            return _financePropertyValueSetRepository.AddPropertyValues(finance.Id, properties);
        }

        public CustomerFinanceModel CreateEmptyCustomerFinance()
        {
            var properties = _financePropertySearchRepository.GetEntities(UserContext.Current.SubscriberId, s => true);
            var propertyValues = properties.Select(s => s.CreateEmptyValue()).ToList();
            var finance = new CustomerFinanceModel
            {
                Properties = Mapper.Map<List<CustomerFinancePropertyValueModel>>(propertyValues)
            };
            return finance;
        }

        public bool DeleteCustomerFinance(Guid financeId)
        {
            return _financeRepository.DeleteCustomerFinance(UserContext.Current.SubscriberId, financeId);
        }
    }
}
