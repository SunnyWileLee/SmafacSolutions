using Smafac.Framework.Core.Repositories;
using Smafac.Hrs.Employee.Domain;
using Smafac.Hrs.Employee.Models;
using Smafac.Hrs.Employee.Repositories.Joiners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Employee.Repositories
{
    class EmployeeSearchRepository : EntitySearchRepository<EmployeeContext, EmployeeEntity>, IEmployeeSearchRepository
    {
        private readonly IEmployeeJoiner _goodsJoiner;

        public EmployeeSearchRepository(IEmployeeContextProvider contextProvider,
                                    IEmployeeJoiner goodsJoiner)
        {
            base.ContextProvider = contextProvider;
            _goodsJoiner = goodsJoiner;
        }

        public List<EmployeeModel> GetEmployee(Guid subscriberId, Expression<Func<EmployeeEntity, bool>> predicate)
        {
            using (var context = ContextProvider.Provide())
            {
                var goodses = context.Employees.Where(s => s.SubscriberId == subscriberId).Where(predicate);
                return _goodsJoiner.Join(goodses, context.EmployeeCategories).ToList();
            }
        }

        public EmployeeModel GetEmployee(Guid subscriberId, Guid goodsId)
        {
            using (var context = ContextProvider.Provide())
            {
                var goodses = context.Employees.Where(s => s.SubscriberId == subscriberId && s.Id == goodsId);
                return _goodsJoiner.Join(goodses, context.EmployeeCategories).FirstOrDefault();
            }
        }
    }
}
