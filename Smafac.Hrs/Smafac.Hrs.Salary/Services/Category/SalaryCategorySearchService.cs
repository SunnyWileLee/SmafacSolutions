using Smafac.Framework.Core.Services.Category;
using Smafac.Hrs.Salary.Applications.Category;
using Smafac.Hrs.Salary.Domain;
using Smafac.Hrs.Salary.Domain.Property;
using Smafac.Hrs.Salary.Models;
using Smafac.Hrs.Salary.Repositories.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Salary.Services.Category
{
    class SalaryCategorySearchService : CategorySearchService<SalaryCategoryEntity, SalaryCategoryModel>, ISalaryCategorySearchService
    {
        public SalaryCategorySearchService(ISalaryCategorySearchRepository goodsSearchRepository,
            ISalaryPropertyProvider goodsCategoryProvider)
        {
            base.CategorySearchRepository = goodsSearchRepository;
        }
    }
}
