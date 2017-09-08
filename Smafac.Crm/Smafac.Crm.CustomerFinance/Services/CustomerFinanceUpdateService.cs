using Smafac.Crm.CustomerFinance.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Crm.CustomerFinance.Models;
using Smafac.Crm.CustomerFinance.Repositories.PropertyValue;
using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Framework.Core.Models;
using AutoMapper;
using Smafac.Crm.CustomerFinance.Repositories;

namespace Smafac.Crm.CustomerFinance.Services
{
    class CustomerFinanceUpdateService : ICustomerFinanceUpdateService
    {
        private readonly ICustomerFinanceUpdateRepository _financeUpdateRepository;
        private readonly ICustomerFinancePropertyValueSetRepository _financePropertyValueSetRepository;

        public CustomerFinanceUpdateService(ICustomerFinanceUpdateRepository financeUpdateRepository,
                                            ICustomerFinancePropertyValueSetRepository financePropertyValueSetRepository)
        {
            _financeUpdateRepository = financeUpdateRepository;
            _financePropertyValueSetRepository = financePropertyValueSetRepository;
        }

        public bool UpdateCustomerFinance(CustomerFinanceModel model)
        {
            var finance = Mapper.Map<CustomerFinanceEntity>(model);
            finance.SubscriberId = UserContext.Current.SubscriberId;
            var update = _financeUpdateRepository.UpdateEntity(finance);

            if (update && model.HasProperties)
            {
                model.Properties.ForEach(property =>
                {
                    property.CustomerFinanceId = finance.Id;
                    property.SubscriberId = finance.SubscriberId;
                    var value = Mapper.Map<CustomerFinancePropertyValueEntity>(property);
                    update &= _financePropertyValueSetRepository.SetPropertyValue(value);
                });
            }
            return update;
        }
    }
}
