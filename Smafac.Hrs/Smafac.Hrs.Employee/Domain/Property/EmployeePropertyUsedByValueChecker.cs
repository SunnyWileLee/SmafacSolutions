using Smafac.Framework.Core.Domain.Property;
using Smafac.Hrs.Employee.Models;
using Smafac.Hrs.Employee.Repositories.PropertyValue;

namespace Smafac.Hrs.Employee.Domain.Property
{
    class EmployeePropertyUsedByValueChecker : PropertyUsedByValueChecker<EmployeePropertyEntity, EmployeePropertyValueModel>,
                                                IEmployeePropertyUsedChecker
    {
        public EmployeePropertyUsedByValueChecker(IEmployeePropertyValueSearchRepository goodsPropertyValueSearchRepository)
        {
            base.PropertyValueSearchRepository = goodsPropertyValueSearchRepository;
        }
    }
}
