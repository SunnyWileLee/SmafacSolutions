using AutoMapper;
using Smafac.Framework.Core.Models;
using Smafac.Hrs.Employee.Domain;
using Smafac.Hrs.Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Employee.Services
{
    class EmployeeAutoMapper : SmafacAutoMapper
    {
        public override void CreateMapper(IMapperConfigurationExpression cfg)
        {
            base.BipassMapper<EmployeeEntity, EmployeeModel>(cfg);
            base.BipassMapper<EmployeePropertyEntity, EmployeePropertyModel>(cfg);
            base.BipassMapper<EmployeePropertyValueEntity, EmployeePropertyValueModel>(cfg);
            base.BipassMapper<EmployeeCategoryEntity, EmployeeCategoryModel>(cfg);
        }
    }
}
