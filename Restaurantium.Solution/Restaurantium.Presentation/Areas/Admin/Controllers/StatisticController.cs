using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurantium.Dto.AboutDtos;
using Restaurantium.Dto.StatisticDtos;

namespace Restaurantium.Presentation.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    [Area("Admin")]
    [Route("Admin/Statistic")]
    public class StatisticController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            #region Şef Sayısı
            var responseMessage = await client.GetAsync("https://localhost:44308/api/Statistics/GetChefCount");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<ResultChefCountDto>(jsonData);

                ViewBag.ChefCount = value.chefCount;
            }

            #endregion

            #region Yemek Sayısı
            var responseMessage2 = await client.GetAsync("https://localhost:44308/api/Statistics/GetMealCount");

            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<ResultMealCountDto>(jsonData);

                ViewBag.MealCount = value.mealCount;
            }
            #endregion

            #region Hizmet Sayısı
            var responseMessage3 = await client.GetAsync("https://localhost:44308/api/Statistics/GetServiceCount");

            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage3.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<ResultServiceCountDto>(jsonData);

                ViewBag.ServiceCount = value.serviceCount;
            }
            #endregion

            #region Referans Sayısı
            var responseMessage4 = await client.GetAsync("https://localhost:44308/api/Statistics/GetTestimonialCount");

            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage4.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<ResultTestimonialCountDto>(jsonData);

                ViewBag.TestimonialCount = value.testimonialCount;
            }
            #endregion

            #region Abone Sayısı
            var responseMessage5 = await client.GetAsync("https://localhost:44308/api/Statistics/GetSubscribeCount");

            if (responseMessage5.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage5.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<ResultSubscribeCountDto>(jsonData);

                ViewBag.SubscribeCount = value.subscribeCount;
            }
            #endregion

            #region Ortalama Yemek Ücreti
            var responseMessage6 = await client.GetAsync("https://localhost:44308/api/Statistics/GetAvgMealPrice");

            if (responseMessage6.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage6.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<ResultGetAvgMealPriceDto>(jsonData);

                ViewBag.AvgMealPrice = value.avgMealPrice;
            }
            #endregion
            
            #region Ortalama Kahvaltı Ücreti
            var responseMessage7 = await client.GetAsync("https://localhost:44308/api/Statistics/GetAvgBreakfastPrice");

            if (responseMessage7.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage7.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<ResultGetAvgBreakfastPriceDto>(jsonData);

                ViewBag.AvgBreakfastPrice = value.avgBreakfastPrice;
            }
            #endregion

            #region Ortalama Öğle Yemeği Ücreti
            var responseMessage8 = await client.GetAsync("https://localhost:44308/api/Statistics/GetAvgLunchPrice");

            if (responseMessage8.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage8.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<ResultGetAvgLunchPriceDto>(jsonData);

                ViewBag.AvgLunchPrice = value.avgLunchPrice;
            }
            #endregion

            #region Ortalama Akşam Yemeği Ücreti
            var responseMessage9 = await client.GetAsync("https://localhost:44308/api/Statistics/GetAvgDinnerPrice");

            if (responseMessage9.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage9.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<ResultGetAvgDinnerPriceDto>(jsonData);

                ViewBag.AvgDinnerPrice = value.avgDinnerPrice;
            }
            #endregion

            #region En Pahalı Yemek
            var responseMessage10 = await client.GetAsync("https://localhost:44308/api/Statistics/GetMostExpensiveMeal");

            if (responseMessage10.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage10.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<ResultGetMostExpensiveMealDto>(jsonData);

                ViewBag.MostExpensiveMeal = value.mostExpensiveMeal;
            }
            #endregion

            #region En Ucuz Yemek
            var responseMessage11 = await client.GetAsync("https://localhost:44308/api/Statistics/GetCheapestMeal");

            if (responseMessage11.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage11.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<ResultGetCheapestMealDto>(jsonData);

                ViewBag.CheapestMeal = value.cheapestMeal;
            }
            #endregion

            #region Müşterilerden Gelen Mesaj Sayısı
            var responseMessage12 = await client.GetAsync("https://localhost:44308/api/Statistics/GetContactMessageCount");

            if (responseMessage12.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage12.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<ResultGetContactMessageCountDto>(jsonData);

                ViewBag.ContactMessageCount = value.contactMessageCount;
               
            }

            #endregion

            return View();
        }
    }
}