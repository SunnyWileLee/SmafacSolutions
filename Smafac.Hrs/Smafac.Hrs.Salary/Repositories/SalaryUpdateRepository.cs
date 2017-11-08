using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Hrs.Salary.Models;
using Smafac.Framework.Core.Repositories;
using Smafac.Hrs.Salary.Domain;

namespace Smafac.Hrs.Salary.Repositories
{
    class SalaryUpdateRepository : EntityUpdateRepository<SalaryContext, SalaryEntity>,
                                    ISalaryUpdateRepository
    {
        public SalaryUpdateRepository(ISalaryContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }

        protected override void SetValue(SalaryEntity entity, SalaryEntity source)
        {
            entity.Amount = source.Amount;
            entity.SalaryDate = source.SalaryDate;
        }
    }
}
