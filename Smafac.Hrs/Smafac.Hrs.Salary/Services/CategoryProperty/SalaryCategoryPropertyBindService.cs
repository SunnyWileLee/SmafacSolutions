using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Framework.Core.Services.CategoryProperty;
using Smafac.Hrs.Salary.Applications.CategoryProperty;
using Smafac.Hrs.Salary.Domain;
using Smafac.Hrs.Salary.Domain.CategoryProperty;
using Smafac.Hrs.Salary.Repositories.Category;
using Smafac.Hrs.Salary.Repositories.CategoryProperty;
using Smafac.Hrs.Salary.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Salary.Services.CategoryProperty
{
    class SalaryCategoryPropertyBindService : CategoryPropertyBindService<SalaryCategoryEntity, SalaryPropertyEntity>,
                                        ISalaryCategoryPropertyBindService
    {
        public SalaryCategoryPropertyBindService(ISalaryCategoryPropertyBindRepository goodsCategoryPropertyBindRepository,
                                                ISalaryCategoryPropertySearchRepository goodsCategoryPropertySearchRepository,
                                                IEnumerable<ISalaryCategoryPropertyBindTrigger> goodsCategoryPropertyBindTriggers,
                                                ISalaryCategorySearchRepository goodsCategorySearchRepository,
                                                ISalaryPropertySearchRepository goodsPropertySearchRepository
                                                )
        {
            base.EntityAssociationBindRepository = goodsCategoryPropertyBindRepository;
            base.EntityAssociationSearchRepository = goodsCategoryPropertySearchRepository;
            base.CategoryAssociationBindTriggers = goodsCategoryPropertyBindTriggers;
            base.CategorySearchRepository = goodsCategorySearchRepository;
            base.AssociationSearchRepository = goodsPropertySearchRepository;
        }
    }
}
