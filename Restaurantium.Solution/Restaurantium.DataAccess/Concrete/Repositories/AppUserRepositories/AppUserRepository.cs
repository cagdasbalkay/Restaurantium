using Microsoft.EntityFrameworkCore;
using Restaurantium.DataAccess.Abstract;
using Restaurantium.DataAccess.Context;
using Restaurantium.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.DataAccess.Concrete.Repositories.AppUserRepositories
{
  
    public class AppUserRepository : IAppUserDal
    {
        private readonly RestaurantiumContext _context;

        public AppUserRepository(RestaurantiumContext context)
        {
            _context = context;
        }

        public Task Create(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<AppUser>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<AppUser?> GetByFilterAsync(Expression<Func<AppUser?, bool>> filter)
        {
            var value = await _context.AppUsers.Where(filter).SingleOrDefaultAsync();
            return value;
        }

        public Task<AppUser> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(AppUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
