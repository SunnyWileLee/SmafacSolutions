using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Hrs.Employee.Models;
using Smafac.Framework.Core.Repositories;
using Smafac.Hrs.Employee.Domain;

namespace Smafac.Hrs.Employee.Repositories
{
    class EmployeeUpdateRepository : EntityUpdateRepository<EmployeeContext, EmployeeEntity>,
                                    IEmployeeUpdateRepository
    {
        public EmployeeUpdateRepository(IEmployeeContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override void SetValue(EmployeeEntity entity, EmployeeEntity source)
        {
            entity.Name = source.Name;
            entity.Phone = source.Phone;
            entity.Identity = source.Identity;
            entity.EmployeeDate = source.EmployeeDate;
        }
    }
}
