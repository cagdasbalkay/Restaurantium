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

namespace Restaurantium.DataAccess.Concrete.Repositories.AppRoleRepositories
{
  
    public class AppRoleRepository : IAppRoleDal
    {
        private readonly RestaurantiumContext _context;

        public AppRoleRepository(RestaurantiumContext context)
        {
            _context = context;
        }

        public Task Create(AppRole entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(AppRole entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<AppRole>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<AppRole?> GetByFilterAsync(Expression<Func<AppRole?, bool>> filter)
        {
            var value = await _context.AppRoles.Where(filter).SingleOrDefaultAsync();
            return value;
        }

        public Task<AppRole> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(AppRole entity)
        {
            throw new NotImplementedException();
        }
    }
}
