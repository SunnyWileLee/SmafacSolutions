﻿using Smafac.Framework.Core.Repositories.Category;
using Smafac.Hrs.Salary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Salary.Repositories.Category
{
    class SalaryCategoryUpdateRepository : CategoryUpdateRepository<SalaryContext, SalaryCategoryEntity>, ISalaryCategoryUpdateRepository
    {
        public SalaryCategoryUpdateRepository(ISalaryContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
