using Smafac.Framework.Core.Repositories;
using Smafac.Hrs.Salary.Domain;
using Smafac.Hrs.Salary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Salary.Repositories
{
    interface ISalarySearchRepository : IEntitySearchRepository<SalaryEntity>
    {
        SalaryModel GetSalary(Guid subscriberId, Guid goodsId);
        List<SalaryModel> GetSalary(Guid subscriberId, Expression<Func<SalaryEntity, bool>> predicate);
    }
}
