using Smafac.Framework.Core.Domain.Property;
using Smafac.Hrs.Salary.Models;
using Smafac.Hrs.Salary.Repositories.PropertyValue;

namespace Smafac.Hrs.Salary.Domain.Property
{
    class SalaryPropertyUsedByValueChecker : PropertyUsedByValueChecker<SalaryPropertyEntity, SalaryPropertyValueModel>,
                                                ISalaryPropertyUsedChecker
    {
        public SalaryPropertyUsedByValueChecker(ISalaryPropertyValueSearchRepository goodsPropertyValueSearchRepository)
        {
            base.PropertyValueSearchRepository = goodsPropertyValueSearchRepository;
        }
    }
}
