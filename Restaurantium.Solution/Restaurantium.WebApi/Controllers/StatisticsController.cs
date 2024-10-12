using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurantium.Business.Concrete;
using Restaurantium.Dto.StatisticDtos;

namespace Restaurantium.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly StatisticManager _statisticManager;

        public StatisticsController(StatisticManager statisticManager)
        {
            _statisticManager = statisticManager;
        }

        [HttpGet("GetChefCount")]
        public IActionResult GetChefCount()
        {
            var count = _statisticManager.GetChefCount();
            return Ok(new ResultChefCountDto
            {
                chefCount = count
            });
        }

        [HttpGet("GetMealCount")]
        public IActionResult GetMealCount()
        {
            var count = _statisticManager.GetMealCount();
            return Ok(new ResultMealCountDto
            {
                mealCount = count
            });
        }

        [HttpGet("GetServiceCount")]
        public IActionResult GetServiceCount()
        {
            var count = _statisticManager.GetServiceCount();
            return Ok(new ResultServiceCountDto
            {
                serviceCount = count
            });
        }

        [HttpGet("GetTestimonialCount")]
        public IActionResult GetTestimonialCount()
        {
            var count = _statisticManager.GetTestimonialCount();
            return Ok(new ResultTestimonialCountDto
            {
                testimonialCount = count
            });
        }

        [HttpGet("GetSubscribeCount")]
        public IActionResult GetSubscribeCount()
        {
            var count = _statisticManager.GetSubscribeCount();
            return Ok(new ResultSubscribeCountDto
            {
                subscribeCount = count
            });
        }

        [HttpGet("GetAvgMealPrice")]
        public IActionResult GetAvgMealPrice()
        {
            var value = _statisticManager.GetAvgMealPrice();
            return Ok(new ResultGetAvgMealPriceDto
            {
                avgMealPrice = value
            });
        }

        [HttpGet("GetAvgBreakfastPrice")]
        public IActionResult GetAvgBreakfastPrice()
        {
            var value = _statisticManager.GetAvgMealPrice();
            return Ok(new ResultGetAvgBreakfastPriceDto
            {
                avgBreakfastPrice = value
            });
        }

        [HttpGet("GetAvgLunchPrice")]
        public IActionResult GetAvgLunchPrice()
        {
            var value = _statisticManager.GetAvgLunchPrice();
            return Ok(new ResultGetAvgLunchPriceDto
            {
                avgLunchPrice = value
            });
        }

        [HttpGet("GetAvgDinnerPrice")]
        public IActionResult GetAvgDinnerPrice()
        {
            var value = _statisticManager.GetAvgDinnerPrice();
            return Ok(new ResultGetAvgDinnerPriceDto
            {
                avgDinnerPrice = value
            });
        }

        [HttpGet("GetMostExpensiveMeal")]
        public IActionResult GetMostExpensiveMeal()
        {
            var value = _statisticManager.GetMostExpensiveMeal();
            return Ok(new ResultGetMostExpensiveMealDto
            {
               mostExpensiveMeal = value
            });
        }

        [HttpGet("GetCheapestMeal")]
        public IActionResult GetCheapestMeal()
        {
            var value = _statisticManager.GetCheapestMeal();
            return Ok(new ResultGetCheapestMealDto
            {
                cheapestMeal = value
            });
        }

        [HttpGet("GetContactMessageCount")]
        public IActionResult GetContactMessageCount()
        {
            var value = _statisticManager.GetContactMessageCount();
            return Ok(new ResultGetContactMessageCountDto
            {
                contactMessageCount = value
            });
        }
    }
}
