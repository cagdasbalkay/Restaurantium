using Microsoft.EntityFrameworkCore;
using Restaurantium.DataAccess.Abstract;
using Restaurantium.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.DataAccess.Concrete.Repositories.StatisticRepositories
{
    public class StatisticRepository : IStatisticDal
    {
        private readonly RestaurantiumContext _restaurantiumContext;

        public StatisticRepository(RestaurantiumContext restaurantiumContext)
        {
            _restaurantiumContext = restaurantiumContext;
        }

        public decimal GetAvgBreakfastPrice()
        {
            decimal avgPrice = _restaurantiumContext.Foods.Where(x => x.Categories.Any(y => y.CategoryID == 1)).Average(z => z.Price);
            return avgPrice;
        }

        public decimal GetAvgDinnerPrice()
        {
            decimal avgPrice = _restaurantiumContext.Foods.Where(x => x.Categories.Any(y => y.CategoryID == 3)).Average(z => z.Price);
            return avgPrice;
        }

        public decimal GetAvgLunchPrice()
        {
            decimal avgPrice = _restaurantiumContext.Foods.Where(x => x.Categories.Any(y => y.CategoryID == 2)).Average(z => z.Price);
            return avgPrice;
        }

        public decimal GetAvgMealPrice()
        {
            decimal avgPrice = _restaurantiumContext.Foods.Average(x => x.Price);
            return avgPrice;
        }

        public string GetCheapestMeal()
        {
            var value = _restaurantiumContext.Foods.OrderBy(x => x.Price).FirstOrDefault();
            if(value != null)
                return value.FoodName;
            return "Tabloda veri yok";
        }

        public int GetChefCount()
        {
            int count = _restaurantiumContext.Chefs.Count();
            return count;
        }

        public int GetContactMessageCount()
        {
            int count = _restaurantiumContext.Contacts.Count();
            return count;
        }

        public int GetMealCount()
        {
            int count = _restaurantiumContext.Foods.Count();
            return count;
        }

        public string GetMostExpensiveMeal()
        {
            var value = _restaurantiumContext.Foods.OrderByDescending(x => x.Price).FirstOrDefault();
            if (value != null)
                return value.FoodName;
            return "Tabloda veri yok";
        }

        public int GetServiceCount()
        {
            int count = _restaurantiumContext.Services.Count();
            return count;
        }

        public int GetSubscribeCount()
        {
            int count = _restaurantiumContext.Subscribes.Count();
            return count;
        }

        public int GetTestimonialCount()
        {
            int count = _restaurantiumContext.Testimonials.Count();
            return count;
        }
    }
}
