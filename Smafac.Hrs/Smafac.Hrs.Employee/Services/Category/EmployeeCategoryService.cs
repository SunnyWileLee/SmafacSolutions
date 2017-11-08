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
        private readonly IEmployeeCategoryAddService _goodsCategoryAddService;
        private readonly IEmployeeCategoryDeleteService _goodsCategoryDeleteService;
        private readonly IEmployeeCategorySearchService _goodsCategorySearchService;
        private readonly IEmployeeCategoryUpdateService _goodsCategoryUpdateService;

        public EmployeeCategoryService(IEmployeeCategoryAddService goodsCategoryAddService,
            IEmployeeCategoryDeleteService goodsCategoryDeleteService,
            IEmployeeCategorySearchService goodsCategorySearchService,
            IEmployeeCategoryUpdateService goodsCategoryUpdateService)
        {
            _goodsCategoryAddService = goodsCategoryAddService;
            _goodsCategoryDeleteService = goodsCategoryDeleteService;
            _goodsCategorySearchService = goodsCategorySearchService;
            _goodsCategoryUpdateService = goodsCategoryUpdateService;
        }

        public ICategoryAddService<EmployeeCategoryModel> AddService => _goodsCategoryAddService;

        public ICategoryDeleteService<EmployeeCategoryModel> DeleteService => _goodsCategoryDeleteService;

        public ICategoryUpdateService<EmployeeCategoryModel> UpdateService => _goodsCategoryUpdateService;

        public ICategorySearchService<EmployeeCategoryModel> SearchService => _goodsCategorySearchService;
    }
}
