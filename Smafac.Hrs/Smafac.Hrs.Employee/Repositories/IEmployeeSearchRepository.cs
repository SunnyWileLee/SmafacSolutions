using Smafac.Framework.Core.Repositories;
using Smafac.Hrs.Employee.Domain;
using Smafac.Hrs.Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Employee.Repositories
{
    interface IEmployeeSearchRepository : IEntitySearchRepository<EmployeeEntity>
    {
        EmployeeModel GetEmployee(Guid subscriberId, Guid goodsId);
        List<EmployeeModel> GetEmployee(Guid subscriberId, Expression<Func<EmployeeEntity, bool>> predicate);
    }
}
