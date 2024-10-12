using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurantium.Dto.StatisticDtos;
using System.Net.Http;

namespace Restaurantium.Presentation.Areas.Admin.ViewComponents.DashboardViewComponents
{
    public class DashboardStatisticVC : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardStatisticVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
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

            #region Referans Sayısı
            var responseMessage4 = await client.GetAsync("https://localhost:44308/api/Statistics/GetTestimonialCount");

            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage4.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<ResultTestimonialCountDto>(jsonData);

                ViewBag.TestimonialCount = value.testimonialCount;
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

           

            return View();
        }


    }

    
}
