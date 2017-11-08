using Smafac.Framework.Core.Repositories;
using Smafac.Hrs.Salary.Domain;
using Smafac.Hrs.Salary.Models;
using Smafac.Hrs.Salary.Repositories.Joiners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Salary.Repositories
{
    class SalarySearchRepository : EntitySearchRepository<SalaryContext, SalaryEntity>, ISalarySearchRepository
    {
        private readonly ISalaryJoiner _goodsJoiner;

        public SalarySearchRepository(ISalaryContextProvider goodsContextProvider,
                                    ISalaryJoiner goodsJoiner)
        {
            base.ContextProvider = goodsContextProvider;
            _goodsJoiner = goodsJoiner;
        }

        public List<SalaryModel> GetSalary(Guid subscriberId, Expression<Func<SalaryEntity, bool>> predicate)
        {
            using (var context = ContextProvider.Provide())
            {
                var goodses = context.Salarys.Where(s => s.SubscriberId == subscriberId).Where(predicate);
                return _goodsJoiner.Join(goodses, context.SalaryCategories).ToList();
            }
        }

        public SalaryModel GetSalary(Guid subscriberId, Guid goodsId)
        {
            using (var context = ContextProvider.Provide())
            {
                var goodses = context.Salarys.Where(s => s.SubscriberId == subscriberId && s.Id == goodsId);
                return _goodsJoiner.Join(goodses, context.SalaryCategories).FirstOrDefault();
            }
        }
    }
}
