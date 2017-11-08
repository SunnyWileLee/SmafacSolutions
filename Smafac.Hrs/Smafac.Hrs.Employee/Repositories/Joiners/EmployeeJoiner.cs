using Smafac.Hrs.Employee.Domain;
using Smafac.Hrs.Employee.Models;
using System.Linq;

namespace Smafac.Hrs.Employee.Repositories.Joiners
{
    class EmployeeJoiner : IEmployeeJoiner
    {
        public IQueryable<EmployeeModel> Join(IQueryable<EmployeeEntity> employees, IQueryable<EmployeeCategoryEntity> categories)
        {
            var query = from employee in employees
                        join category in categories on employee.CategoryId equals category.Id
                        select new EmployeeModel
                        {
                            CategoryId = employee.CategoryId,
                            SubscriberId = employee.SubscriberId,
                            CategoryName = category.Name,
                            CreateTime = employee.CreateTime,
                            Id = employee.Id,
                            Identity = employee.Identity,
                            Name = employee.Name,
                            Phone = employee.Phone,
                            EmployeeDate = employee.EmployeeDate
                        };
            return query;
        }
    }
}
