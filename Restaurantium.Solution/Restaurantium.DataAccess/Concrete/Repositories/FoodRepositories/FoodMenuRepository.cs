using Microsoft.EntityFrameworkCore;
using Restaurantium.DataAccess.Abstract;
using Restaurantium.DataAccess.Context;
using Restaurantium.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.DataAccess.Concrete.Repositories.FoodRepositories
{
   
    public class FoodMenuRepository : IFoodMenuDal
    {
        private readonly RestaurantiumContext _context;

        public FoodMenuRepository(RestaurantiumContext context)
        {
            _context = context;
        }

        public List<Food> Get8FoodsPerCategory(int categoryId)
        {
            var foods = _context.Categories.Where(c => c.CategoryID == categoryId).SelectMany(c => c.Foods).Take(8).ToList();
            return foods;
        }

        public List<Food> GetFoodsByCategoryId(int categoryId)
        {
            var foods = _context.Categories
                             .Where(c => c.CategoryID == categoryId)
                             .SelectMany(c => c.Foods)
                             .ToList();

            return foods;
        }
    }
}
