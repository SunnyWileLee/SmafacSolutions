using Smafac.Hrs.Employee.Applications.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Core.Applications.Category;
using Smafac.Hrs.Employee.Models;

namespace Smafac.Hrs.Employee.Services.Category
{
    class EmployeeCategoryService : IEmployeeCategoryService
    {
        private readonly IEmployeeCategoryAddService _categoryAddService;
        private readonly IEmployeeCategoryDeleteService _categoryDeleteService;
        private readonly IEmployeeCategorySearchService _categorySearchService;
        private readonly IEmployeeCategoryUpdateService _categoryUpdateService;

        public EmployeeCategoryService(IEmployeeCategoryAddService categoryAddService,
            IEmployeeCategoryDeleteService categoryDeleteService,
            IEmployeeCategorySearchService categorySearchService,
            IEmployeeCategoryUpdateService categoryUpdateService)
        {
            _categoryAddService = categoryAddService;
            _categoryDeleteService = categoryDeleteService;
            _categorySearchService = categorySearchService;
            _categoryUpdateService = categoryUpdateService;
        }

        public ICategoryAddService<EmployeeCategoryModel> AddService => _categoryAddService;

        public ICategoryDeleteService<EmployeeCategoryModel> DeleteService => _categoryDeleteService;

        public ICategoryUpdateService<EmployeeCategoryModel> UpdateService => _categoryUpdateService;

        public ICategorySearchService<EmployeeCategoryModel> SearchService => _categorySearchService;
    }
}
