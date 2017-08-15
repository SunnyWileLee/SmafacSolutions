using AutoMapper;
using Smafac.Crm.Customer.Domain;
using Smafac.Crm.Customer.Models;
using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Crm.Customer.Services
{
    class CustomerAutoMapper : SmafacAutoMapper
    {
        public override void CreateMapper(IMapperConfigurationExpression cfg)
        {
            base.BipassMapper<CustomerEntity, CustomerModel>(cfg);
            base.BipassMapper<CustomerPropertyEntity, CustomerPropertyModel>(cfg);
            base.BipassMapper<CustomerPropertyValueEntity, CustomerPropertyValueModel>(cfg);
            base.BipassMapper<CustomerLevelEntity, CustomerLevelModel>(cfg);
            base.BipassMapper<CustomerFinancialEntity, CustomerFinancialModel>(cfg);
            base.BipassMapper<CustomerFinancialTypeEntity, CustomerFinancialTypeModel>(cfg);
            base.BipassMapper<CustomerFinancialStatusEntity, CustomerFinancialStatusModel>(cfg);
            base.BipassMapper<CustomerPayTypeEntity, CustomerPayTypeModel>(cfg);
            base.BipassMapper<CustomerContactEntity, CustomerContactModel>(cfg);
            base.BipassMapper<CustomerContactPropertyEntity, CustomerContactPropertyModel>(cfg);
            base.BipassMapper<CustomerContactPropertyValueEntity, CustomerContactPropertyValueModel>(cfg);
            base.BipassMapper<CustomerScoreEntity, CustomerScoreModel>(cfg);
            base.BipassMapper<CustomerVisitEntity, CustomerVisitModel>(cfg);
            base.BipassMapper<CustomerReceiveEntity, CustomerReceiveModel>(cfg);
        }
    }
}
