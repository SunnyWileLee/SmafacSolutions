using Smafac.Framework.Core.Repositories.CategoryProperty;
using Smafac.Framework.Core.Services.CategoryProperty;
using Smafac.Hrs.Employee.Applications.CategoryProperty;
using Smafac.Hrs.Employee.Domain;
using Smafac.Hrs.Employee.Domain.CategoryProperty;
using Smafac.Hrs.Employee.Repositories.Category;
using Smafac.Hrs.Employee.Repositories.CategoryProperty;
using Smafac.Hrs.Employee.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Employee.Services.CategoryProperty
{
    class EmployeeCategoryPropertyBindService : CategoryPropertyBindService<EmployeeCategoryEntity, EmployeePropertyEntity>,
                                        IEmployeeCategoryPropertyBindService
    {
        public EmployeeCategoryPropertyBindService(IEmployeeCategoryPropertyBindRepository categoryPropertyBindRepository,
                                                IEmployeeCategoryPropertySearchRepository categoryPropertySearchRepository,
                                                IEnumerable<IEmployeeCategoryPropertyBindTrigger> categoryPropertyBindTriggers,
                                                IEmployeeCategorySearchRepository categorySearchRepository,
                                                IEmployeePropertySearchRepository propertySearchRepository
                                                )
        {
            base.EntityAssociationBindRepository = categoryPropertyBindRepository;
            base.EntityAssociationSearchRepository = categoryPropertySearchRepository;
            base.CategoryAssociationBindTriggers = categoryPropertyBindTriggers;
            base.CategorySearchRepository = categorySearchRepository;
            base.AssociationSearchRepository = propertySearchRepository;
        }
    }
}
