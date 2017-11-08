using Smafac.Framework.Core.Repositories.Pages;
using Smafac.Hrs.Employee.Domain;
using Smafac.Hrs.Employee.Models;
using Smafac.Hrs.Employee.Repositories.Joiners;
using System.Collections.Generic;
using System.Linq;

namespace Smafac.Hrs.Employee.Repositories.Pages
{
    class EmployeePageQueryRepository : PageQueryRepository<EmployeeContext, EmployeeEntity, EmployeeModel>
                                                , IEmployeePageQueryRepository
    {
        private readonly IEmployeeJoiner _goodsJoiner;

        public EmployeePageQueryRepository(IEmployeeContextProvider contextProvider,
                                        IEmployeeJoiner goodsJoiner)
        {
            base.ContextProvider = contextProvider;
            _goodsJoiner = goodsJoiner;
        }

        protected override List<EmployeeModel> SelectModel(IQueryable<EmployeeEntity> query, EmployeeContext context)
        {
            var models = _goodsJoiner.Join(query, context.EmployeeCategories);
            return models.ToList();
        }
    }
}
