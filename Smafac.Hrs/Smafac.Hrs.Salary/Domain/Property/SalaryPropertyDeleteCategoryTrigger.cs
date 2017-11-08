using Smafac.Framework.Core.Domain.Property;
using Smafac.Hrs.Salary.Repositories.CategoryProperty;

namespace Smafac.Hrs.Salary.Domain.Property
{
    class CustomerPropertyDeleteCategoryTrigger : PropertyDeleteCategoryTrigger<SalaryCategoryEntity, SalaryPropertyEntity, SalaryCategoryPropertyEntity>,
        ISalaryPropertyDeleteTrigger
    {
        public CustomerPropertyDeleteCategoryTrigger(ISalaryCategoryPropertyBindRepository goodsCategoryPropertyBindRepository)
        {
            base.CategoryPropertyBindRepository = goodsCategoryPropertyBindRepository;
        }
    }
}
