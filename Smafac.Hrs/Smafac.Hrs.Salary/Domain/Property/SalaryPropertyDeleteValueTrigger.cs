using Smafac.Framework.Core.Domain.Property;
using Smafac.Hrs.Salary.Repositories.PropertyValue;

namespace Smafac.Hrs.Salary.Domain.Property
{
    class CustomerPropertyDeleteValueTrigger : PropertyDeleteValueTrigger<SalaryPropertyEntity, SalaryPropertyValueEntity>,
                                            ISalaryPropertyDeleteTrigger
    {
        public CustomerPropertyDeleteValueTrigger(ISalaryPropertyValueDeleteRepository goodsPropertyValueDeleteRepository)
        {
            base.PropertyValueDeleteRepository = goodsPropertyValueDeleteRepository;
        }
    }
}
