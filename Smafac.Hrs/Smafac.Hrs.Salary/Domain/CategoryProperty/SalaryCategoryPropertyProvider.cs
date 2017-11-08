using Smafac.Framework.Core.Domain.EntityAssociationProviders;
using Smafac.Hrs.Salary.Models;
using Smafac.Hrs.Salary.Repositories.Category;
using Smafac.Hrs.Salary.Repositories.CategoryProperty;

namespace Smafac.Hrs.Salary.Domain.CategoryProperty
{
    class SalaryCategoryPropertyProvider : CategoryPropertyProvider<SalaryCategoryEntity, SalaryPropertyEntity, SalaryPropertyModel>,
                                            ISalaryCategoryPropertyProvider
    {

        public SalaryCategoryPropertyProvider(ISalaryCategoryPropertySearchRepository goodsCategoryPropertySearchRepository,
                                            ISalaryCategorySearchRepository goodsCategorySearchRepository)
        {
            base.CategorySearchRepository = goodsCategorySearchRepository;
            base.CategoryAssociationSearchRepository = goodsCategoryPropertySearchRepository;
        }
    }
}
