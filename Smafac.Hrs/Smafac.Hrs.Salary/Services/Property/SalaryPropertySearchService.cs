using Smafac.Framework.Core.Services.Property;
using Smafac.Hrs.Salary.Applications.Property;
using Smafac.Hrs.Salary.Domain;
using Smafac.Hrs.Salary.Domain.Property;
using Smafac.Hrs.Salary.Models;
using Smafac.Hrs.Salary.Repositories.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Salary.Services.Property
{
    class SalaryPropertySearchService : PropertySearchService<SalaryPropertyEntity, SalaryPropertyModel>, ISalaryPropertySearchService
    {
        private readonly ISalaryPropertyProvider _goodsPropertyProvider;

        public SalaryPropertySearchService(ISalaryPropertySearchRepository goodsSearchRepository,
            ISalaryPropertyProvider goodsPropertyProvider)
        {
            base.CustomizedColumnSearchRepository = goodsSearchRepository;
            _goodsPropertyProvider = goodsPropertyProvider;
        }

        public override List<SalaryPropertyModel> GetColumns(Guid entityId)
        {
            return _goodsPropertyProvider.Provide(entityId);
        }
    }
}
