using Smafac.Hrs.Employee.Applications.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Hrs.Employee.Models;
using Smafac.Framework.Core.Services.Category;
using Smafac.Hrs.Employee.Domain;
using Smafac.Hrs.Employee.Repositories.Category;

namespace Smafac.Hrs.Employee.Services.Category
{
    class EmployeeCategoryAddService : CategoryAddService<EmployeeCategoryEntity, EmployeeCategoryModel>, IEmployeeCategoryAddService
    {
        public EmployeeCategoryAddService(IEmployeeCategoryAddRepository goodsCategoryAddRepository,
                                        IEmployeeCategorySearchRepository goodsCategorySearchRepository)
        {
            base.CategoryAddRepository = goodsCategoryAddRepository;
            base.CategorySearchRepository = goodsCategorySearchRepository;
        }
    }
}
