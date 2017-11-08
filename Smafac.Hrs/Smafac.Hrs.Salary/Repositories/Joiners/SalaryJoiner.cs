using Smafac.Hrs.Salary.Domain;
using Smafac.Hrs.Salary.Models;
using System.Linq;

namespace Smafac.Hrs.Salary.Repositories.Joiners
{
    class SalaryJoiner : ISalaryJoiner
    {
        public IQueryable<SalaryModel> Join(IQueryable<SalaryEntity> salarys, IQueryable<SalaryCategoryEntity> categories)
        {
            var query = from salary in salarys
                        join category in categories on salary.CategoryId equals category.Id
                        select new SalaryModel
                        {
                            CategoryId = salary.CategoryId,
                            SubscriberId = salary.SubscriberId,
                            CategoryName = category.Name,
                            CreateTime = salary.CreateTime,
                            Id = salary.Id,
                            Amount = salary.Amount,
                            SalaryDate = salary.SalaryDate
                        };
            return query;
        }
    }
}
