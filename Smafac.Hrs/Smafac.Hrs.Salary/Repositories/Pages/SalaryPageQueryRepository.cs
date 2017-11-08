using Smafac.Framework.Core.Repositories.Pages;
using Smafac.Hrs.Salary.Domain;
using Smafac.Hrs.Salary.Models;
using Smafac.Hrs.Salary.Repositories.Joiners;
using System.Collections.Generic;
using System.Linq;

namespace Smafac.Hrs.Salary.Repositories.Pages
{
    class SalaryPageQueryRepository : PageQueryRepository<SalaryContext, SalaryEntity, SalaryModel>
                                                , ISalaryPageQueryRepository
    {
        private readonly ISalaryJoiner _goodsJoiner;

        public SalaryPageQueryRepository(ISalaryContextProvider contextProvider,
                                        ISalaryJoiner goodsJoiner)
        {
            base.ContextProvider = contextProvider;
            _goodsJoiner = goodsJoiner;
        }

        protected override List<SalaryModel> SelectModel(IQueryable<SalaryEntity> query, SalaryContext context)
        {
            var models = _goodsJoiner.Join(query, context.SalaryCategories);
            return models.ToList();
        }
    }
}
