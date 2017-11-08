using Smafac.Framework.Core.Services.CategoryProperty;
using Smafac.Hrs.Salary.Applications.CategoryProperty;
using Smafac.Hrs.Salary.Domain;
using Smafac.Hrs.Salary.Domain.CategoryProperty;
using Smafac.Hrs.Salary.Models;
using Smafac.Hrs.Salary.Repositories.CategoryProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Salary.Services.CategoryProperty
{
    class SalaryCategoryPropertySearchService : CategoryPropertySearchService<SalaryCategoryEntity, SalaryPropertyEntity, SalaryPropertyModel>,
                                                ISalaryCategoryPropertySearchService
    {
        public SalaryCategoryPropertySearchService(ISalaryCategoryPropertySearchRepository goodsCategoryPropertySearchRepository,
            ISalaryCategoryPropertyProvider goodsCategoryPropertyProvider
            )
        {
            base.CategoryAssociationProvider = goodsCategoryPropertyProvider;
            base.EntityAssociationSearchRepository = goodsCategoryPropertySearchRepository;
        }
    }
}
