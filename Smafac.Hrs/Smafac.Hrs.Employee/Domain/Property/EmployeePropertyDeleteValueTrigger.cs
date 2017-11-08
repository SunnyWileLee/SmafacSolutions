using Smafac.Framework.Core.Domain.Property;
using Smafac.Hrs.Employee.Repositories.PropertyValue;

namespace Smafac.Hrs.Employee.Domain.Property
{
    class CustomerPropertyDeleteValueTrigger : PropertyDeleteValueTrigger<EmployeePropertyEntity, EmployeePropertyValueEntity>,
                                            IEmployeePropertyDeleteTrigger
    {
        public CustomerPropertyDeleteValueTrigger(IEmployeePropertyValueDeleteRepository goodsPropertyValueDeleteRepository)
        {
            base.PropertyValueDeleteRepository = goodsPropertyValueDeleteRepository;
        }
    }
}
