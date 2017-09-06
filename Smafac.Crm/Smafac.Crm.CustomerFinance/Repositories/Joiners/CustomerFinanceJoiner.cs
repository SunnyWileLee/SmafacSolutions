using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Models;

namespace Smafac.Crm.CustomerFinance.Repositories.Joiners
{
    class CustomerFinanceJoiner : ICustomerFinanceJoiner
    {
        public IQueryable<CustomerFinanceModel> Join(IQueryable<CustomerFinanceEntity> finances, IQueryable<CustomerFinanceCategoryEntity> categories)
        {
            var query = from finance in finances
                        join category in categories on finance.CategoryId equals category.Id
                        select new CustomerFinanceModel
                        {
                            SubscriberId = finance.SubscriberId,
                            Amount = finance.Amount,
                            CategoryId = finance.CategoryId,
                            CategoryName = category.Name,
                            CreateTime = finance.CreateTime,
                            CustomerId = finance.CustomerId,
                            FinanceTime = finance.FinanceTime,
                            Id = finance.Id,
                            Memo = finance.Memo,
                        };
            return query;
        }
    }
}
