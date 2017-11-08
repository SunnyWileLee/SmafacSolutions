using AutoMapper;
using Smafac.Framework.Core.Models;
using Smafac.Hrs.Salary.Domain;
using Smafac.Hrs.Salary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Salary.Services
{
    class SalaryAutoMapper : SmafacAutoMapper
    {
        public override void CreateMapper(IMapperConfigurationExpression cfg)
        {
            base.BipassMapper<SalaryEntity, SalaryModel>(cfg);
            base.BipassMapper<SalaryPropertyEntity, SalaryPropertyModel>(cfg);
            base.BipassMapper<SalaryPropertyValueEntity, SalaryPropertyValueModel>(cfg);
            base.BipassMapper<SalaryCategoryEntity, SalaryCategoryModel>(cfg);
        }
    }
}
