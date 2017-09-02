using AutoMapper;
using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Model;
using Smafac.Framework.Core.Models;

namespace Smafac.Crm.CustomerFinance.Services
{
    class CustomerFinanceAutoMapper : SmafacAutoMapper
    {
        public override void CreateMapper(IMapperConfigurationExpression cfg)
        {
            base.BipassMapper<CustomerFinanceEntity, CustomerFinanceModel>(cfg);
            base.BipassMapper<CustomerFinancePropertyEntity, CustomerFinancePropertyModel>(cfg);
            base.BipassMapper<CustomerFinancePropertyValueEntity, CustomerFinancePropertyValueModel>(cfg);
            base.BipassMapper<CustomerFinanceCategoryEntity, CustomerFinanceCategoryModel>(cfg);
        }
    }
}
