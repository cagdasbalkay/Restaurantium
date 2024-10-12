using Microsoft.EntityFrameworkCore;
using Restaurantium.DataAccess.Abstract;
using Restaurantium.DataAccess.Concrete.Repositories;
using Restaurantium.DataAccess.Context;
using Restaurantium.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.DataAccess.EntityFramework
{
    public class EfChefDal : GenericRepository<Chef>, IChefDal
    {
        private readonly RestaurantiumContext _context;
        public EfChefDal(RestaurantiumContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Chef>> Get4ChefsAsync()
        {
            var values = await _context.Chefs.Take(4).ToListAsync();
            return values;
        }
    }
}
