using Smafac.Framework.Core.Domain.Property;
using Smafac.Hrs.Employee.Repositories.CategoryProperty;

namespace Smafac.Hrs.Employee.Domain.Property
{
    class EmployeePropertyUsedByCategoryChecker : PropertyUsedByCategoryChecker<EmployeeCategoryEntity, EmployeePropertyEntity>,
                                                IEmployeePropertyUsedChecker
    {
        public EmployeePropertyUsedByCategoryChecker(IEmployeeCategoryPropertySearchRepository goodsategoryPropertySearchRepository)
        {
            base.CategoryPropertySearchRepository = goodsategoryPropertySearchRepository;
        }
    }
}
