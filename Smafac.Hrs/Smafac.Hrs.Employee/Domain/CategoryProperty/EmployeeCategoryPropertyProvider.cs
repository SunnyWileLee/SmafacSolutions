using Smafac.Framework.Core.Domain.EntityAssociationProviders;
using Smafac.Hrs.Employee.Models;
using Smafac.Hrs.Employee.Repositories.Category;
using Smafac.Hrs.Employee.Repositories.CategoryProperty;

namespace Smafac.Hrs.Employee.Domain.CategoryProperty
{
    class EmployeeCategoryPropertyProvider : CategoryPropertyProvider<EmployeeCategoryEntity, EmployeePropertyEntity, EmployeePropertyModel>,
                                            IEmployeeCategoryPropertyProvider
    {

        public EmployeeCategoryPropertyProvider(IEmployeeCategoryPropertySearchRepository goodsCategoryPropertySearchRepository,
                                            IEmployeeCategorySearchRepository goodsCategorySearchRepository)
        {
            base.CategorySearchRepository = goodsCategorySearchRepository;
            base.CategoryAssociationSearchRepository = goodsCategoryPropertySearchRepository;
        }
    }
}
