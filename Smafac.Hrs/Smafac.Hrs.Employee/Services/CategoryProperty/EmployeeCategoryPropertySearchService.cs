using Smafac.Framework.Core.Services.CategoryProperty;
using Smafac.Hrs.Employee.Applications.CategoryProperty;
using Smafac.Hrs.Employee.Domain;
using Smafac.Hrs.Employee.Domain.CategoryProperty;
using Smafac.Hrs.Employee.Models;
using Smafac.Hrs.Employee.Repositories.CategoryProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Employee.Services.CategoryProperty
{
    class EmployeeCategoryPropertySearchService : CategoryPropertySearchService<EmployeeCategoryEntity, EmployeePropertyEntity, EmployeePropertyModel>,
                                                IEmployeeCategoryPropertySearchService
    {
        public EmployeeCategoryPropertySearchService(IEmployeeCategoryPropertySearchRepository goodsCategoryPropertySearchRepository,
            IEmployeeCategoryPropertyProvider goodsCategoryPropertyProvider
            )
        {
            base.CategoryAssociationProvider = goodsCategoryPropertyProvider;
            base.EntityAssociationSearchRepository = goodsCategoryPropertySearchRepository;
        }
    }
}
