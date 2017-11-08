using Smafac.Framework.Core.Domain.Pages;
using Smafac.Hrs.Salary.Models;

namespace Smafac.Hrs.Salary.Domain.Pages
{
    interface ISalaryPageQueryer : IPageQueryer<SalaryModel, SalaryPageQueryModel>
    {
    }
}
