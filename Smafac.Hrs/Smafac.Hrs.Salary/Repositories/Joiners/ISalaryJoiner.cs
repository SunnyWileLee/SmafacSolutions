using Smafac.Hrs.Salary.Domain;
using Smafac.Hrs.Salary.Models;
using System.Linq;

namespace Smafac.Hrs.Salary.Repositories.Joiners
{
    interface ISalaryJoiner
    {
        IQueryable<SalaryModel> Join(IQueryable<SalaryEntity> goodses, IQueryable<SalaryCategoryEntity> categories);
    }
}
