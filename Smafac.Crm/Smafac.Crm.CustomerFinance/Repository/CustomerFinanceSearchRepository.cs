using Smafac.Crm.CustomerFinance.Domain;
using Smafac.Crm.CustomerFinance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Smafac.Crm.CustomerFinance.Repository
{
    class CustomerFinanceSearchRepository : ICustomerFinanceSearchRepository
    {
        private readonly ICustomerFinanceContextProvider _financeContextProvider;

        public CustomerFinanceSearchRepository(ICustomerFinanceContextProvider financeContextProvider)
        {
            _financeContextProvider = financeContextProvider;
        }

        public CustomerFinanceModel GetById(Guid subscriberId, Guid financeId)
        {
            using (var context = _financeContextProvider.Provide())
            {
                var finances = context.CustomerFinances.Where(s => s.SubscriberId == subscriberId && s.Id == financeId);
                var finance = JoinFinanceCategory(finances, context.CustomerFinanceCategories).FirstOrDefault();
                return finance;
            }
        }

        public int GetCustomerFinanceCount(Guid subscriberId, Expression<Func<CustomerFinanceEntity, bool>> predicate)
        {
            using (var context = _financeContextProvider.Provide())
            {
                var count = context.CustomerFinances.Where(s => s.SubscriberId == subscriberId).Count(predicate);
                return count;
            }
        }

        public List<CustomerFinanceModel> GetCustomerFinancePage(Guid subscriberId, Expression<Func<CustomerFinanceEntity, bool>> predicate, int skip, int take)
        {
            using (var context = _financeContextProvider.Provide())
            {
                var finances = context.CustomerFinances.Where(s => s.SubscriberId == subscriberId)
                                        .Where(predicate).OrderByDescending(s => s.CreateTime)
                                        .Skip(skip).Take(take);
                return JoinFinanceCategory(finances, context.CustomerFinanceCategories).ToList();
            }
        }

        private IQueryable<CustomerFinanceModel> JoinFinanceCategory(IQueryable<CustomerFinanceEntity> finances, IQueryable<CustomerFinanceCategoryEntity> categories)
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
