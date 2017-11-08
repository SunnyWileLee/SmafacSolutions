using Smafac.Framework.Core.Domain.Property;
using Smafac.Hrs.Employee.Repositories.CategoryProperty;

namespace Smafac.Hrs.Employee.Domain.Property
{
    class CustomerPropertyDeleteCategoryTrigger : PropertyDeleteCategoryTrigger<EmployeeCategoryEntity, EmployeePropertyEntity, EmployeeCategoryPropertyEntity>,
        IEmployeePropertyDeleteTrigger
    {
        public CustomerPropertyDeleteCategoryTrigger(IEmployeeCategoryPropertyBindRepository categoryPropertyBindRepository)
        {
            base.CategoryPropertyBindRepository = categoryPropertyBindRepository;
        }
    }
}
