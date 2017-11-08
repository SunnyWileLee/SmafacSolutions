using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Hrs.Salary.Domain;

namespace Smafac.Hrs.Salary.Repositories.PropertyValue
{
    class SalaryPropertyValueDeleteRepository : PropertyValueDeleteRepository<SalaryContext, SalaryPropertyValueEntity>,
                                                ISalaryPropertyValueDeleteRepository
    {

        public SalaryPropertyValueDeleteRepository(ISalaryContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
