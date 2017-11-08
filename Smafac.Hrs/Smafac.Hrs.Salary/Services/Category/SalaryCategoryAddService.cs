using Smafac.Hrs.Salary.Applications.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Hrs.Salary.Models;
using Smafac.Framework.Core.Services.Category;
using Smafac.Hrs.Salary.Domain;
using Smafac.Hrs.Salary.Repositories.Category;

namespace Smafac.Hrs.Salary.Services.Category
{
    class SalaryCategoryAddService : CategoryAddService<SalaryCategoryEntity, SalaryCategoryModel>, ISalaryCategoryAddService
    {
        public SalaryCategoryAddService(ISalaryCategoryAddRepository goodsCategoryAddRepository,
                                        ISalaryCategorySearchRepository goodsCategorySearchRepository)
        {
            base.CategoryAddRepository = goodsCategoryAddRepository;
            base.CategorySearchRepository = goodsCategorySearchRepository;
        }
    }
}
