using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.Business.Abstract
{
    public interface IStatisticService
    {
        int GetChefCount();
        int GetMealCount();
        int GetServiceCount();
        int GetTestimonialCount();
        int GetSubscribeCount();
        decimal GetAvgMealPrice();
        decimal GetAvgBreakfastPrice();
        decimal GetAvgLunchPrice();
        decimal GetAvgDinnerPrice();
        string GetMostExpensiveMeal();
        string GetCheapestMeal();
        int GetContactMessageCount();
    }
}
