using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace Smafac.Presentation.Models
{
    public class UserStore : IUserStore<SmafacUser>
    {
        public Task CreateAsync(SmafacUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(SmafacUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<SmafacUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<SmafacUser> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(SmafacUser user)
        {
            throw new NotImplementedException();
        }
    }
}