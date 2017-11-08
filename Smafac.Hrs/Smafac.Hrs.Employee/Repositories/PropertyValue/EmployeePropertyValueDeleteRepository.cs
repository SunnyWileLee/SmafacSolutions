using Smafac.Framework.Core.Repositories.PropertyValue;
using Smafac.Hrs.Employee.Domain;

namespace Smafac.Hrs.Employee.Repositories.PropertyValue
{
    class EmployeePropertyValueDeleteRepository : PropertyValueDeleteRepository<EmployeeContext, EmployeePropertyValueEntity>,
                                                IEmployeePropertyValueDeleteRepository
    {

        public EmployeePropertyValueDeleteRepository(IEmployeeContextProvider contextProvider)
        {
            base.ContextProvider = contextProvider;
        }
    }
}
