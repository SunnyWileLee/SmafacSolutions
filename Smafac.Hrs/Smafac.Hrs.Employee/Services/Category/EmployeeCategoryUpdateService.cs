using Smafac.Framework.Core.Services.Category;
using Smafac.Hrs.Employee.Applications.Category;
using Smafac.Hrs.Employee.Domain;
using Smafac.Hrs.Employee.Models;
using Smafac.Hrs.Employee.Repositories.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Employee.Services.Category
{
    class EmployeeCategoryUpdateService : CategoryUpdateService<EmployeeCategoryEntity, EmployeeCategoryModel>, IEmployeeCategoryUpdateService
    {
        public EmployeeCategoryUpdateService(IEmployeeCategorySearchRepository categorySearchRepository,
                                          IEmployeeCategoryUpdateRepository categoryUpdateRepository)
        {
            base.CategorySearchRepository = categorySearchRepository;
            base.CategoryUpdateRepository = categoryUpdateRepository;
        }
    }
}
