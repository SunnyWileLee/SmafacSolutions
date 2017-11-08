using Smafac.Framework.Core.Domain.Property;
using Smafac.Hrs.Salary.Repositories.CategoryProperty;

namespace Smafac.Hrs.Salary.Domain.Property
{
    class SalaryPropertyUsedByCategoryChecker : PropertyUsedByCategoryChecker<SalaryCategoryEntity, SalaryPropertyEntity>,
                                                ISalaryPropertyUsedChecker
    {
        public SalaryPropertyUsedByCategoryChecker(ISalaryCategoryPropertySearchRepository goodsategoryPropertySearchRepository)
        {
            base.CategoryPropertySearchRepository = goodsategoryPropertySearchRepository;
        }
    }
}
