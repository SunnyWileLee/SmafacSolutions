using Smafac.Framework.Core.Models;
using Smafac.Hrs.Salary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Hrs.Salary.Applications
{
    public interface ISalarySearchService
    {
        SalaryModel GetSalary(Guid goodsId);
        SalaryDetailModel GetSalaryDetail(Guid goodsId);
        PageModel<SalaryModel> GetSalaryPage(SalaryPageQueryModel query);
        List<SalaryModel> GetSalary(SalaryPageQueryModel query);
        List<SalaryModel> GetSalary(IEnumerable<Guid> goodsIds);
    }
}
