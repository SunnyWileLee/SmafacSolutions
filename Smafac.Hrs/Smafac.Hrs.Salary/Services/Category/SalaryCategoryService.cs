using Smafac.Hrs.Salary.Applications.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Framework.Core.Applications.Category;
using Smafac.Hrs.Salary.Models;

namespace Smafac.Hrs.Salary.Services.Category
{
    class SalaryCategoryService : ISalaryCategoryService
    {
        private readonly ISalaryCategoryAddService _goodsCategoryAddService;
        private readonly ISalaryCategoryDeleteService _goodsCategoryDeleteService;
        private readonly ISalaryCategorySearchService _goodsCategorySearchService;
        private readonly ISalaryCategoryUpdateService _goodsCategoryUpdateService;

        public SalaryCategoryService(ISalaryCategoryAddService goodsCategoryAddService,
            ISalaryCategoryDeleteService goodsCategoryDeleteService,
            ISalaryCategorySearchService goodsCategorySearchService,
            ISalaryCategoryUpdateService goodsCategoryUpdateService)
        {
            _goodsCategoryAddService = goodsCategoryAddService;
            _goodsCategoryDeleteService = goodsCategoryDeleteService;
            _goodsCategorySearchService = goodsCategorySearchService;
            _goodsCategoryUpdateService = goodsCategoryUpdateService;
        }

        public ICategoryAddService<SalaryCategoryModel> AddService => _goodsCategoryAddService;

        public ICategoryDeleteService<SalaryCategoryModel> DeleteService => _goodsCategoryDeleteService;

        public ICategoryUpdateService<SalaryCategoryModel> UpdateService => _goodsCategoryUpdateService;

        public ICategorySearchService<SalaryCategoryModel> SearchService => _goodsCategorySearchService;
    }
}
