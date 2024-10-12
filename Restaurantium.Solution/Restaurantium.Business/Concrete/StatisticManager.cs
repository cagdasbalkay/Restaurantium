using Restaurantium.Business.Abstract;
using Restaurantium.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.Business.Concrete
{
    public class StatisticManager : IStatisticService
    {
        private readonly IStatisticDal _statisticDal;

        public StatisticManager(IStatisticDal statisticDal)
        {
            _statisticDal = statisticDal;
        }

        public decimal GetAvgBreakfastPrice()
        {
            var value = _statisticDal.GetAvgBreakfastPrice();
            return value;
        }

        public decimal GetAvgDinnerPrice()
        {
            var value = _statisticDal.GetAvgDinnerPrice();
            return value;
        }

        public decimal GetAvgLunchPrice()
        {
            var value = _statisticDal.GetAvgLunchPrice();
            return value;
        }

        public decimal GetAvgMealPrice()
        {
            var value = _statisticDal.GetAvgMealPrice();
            return value;
        }

        public string GetCheapestMeal()
        {
            var value = _statisticDal.GetCheapestMeal();
            return value;
        }

        public int GetChefCount()
        {
            var value = _statisticDal.GetChefCount();
            return value;
        }

        public int GetContactMessageCount()
        {
            var value = _statisticDal.GetContactMessageCount();
            return value;
        }

        public int GetMealCount()
        {
            var value = _statisticDal.GetMealCount();
            return value;
        }

        public string GetMostExpensiveMeal()
        {
            var value = _statisticDal.GetMostExpensiveMeal();
            return value;
        }

        public int GetServiceCount()
        {
            var value = _statisticDal.GetServiceCount();
            return value;
        }

        public int GetSubscribeCount()
        {
            var value = _statisticDal.GetSubscribeCount();
            return value;
        }

        public int GetTestimonialCount()
        {
            var value = _statisticDal.GetTestimonialCount();
            return value;
        }
    }
}
