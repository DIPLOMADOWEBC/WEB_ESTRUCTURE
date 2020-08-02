using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Service
{
    public class UserStore<TEntity> : IUserStore<TEntity> where TEntity : ApplicationUser
    {
        public Task CreateAsync(TEntity user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TEntity user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public Task<TEntity> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity user)
        {
            throw new NotImplementedException();
        }
    }
}
