using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurantium.Dto.ChefDtos;

namespace Restaurantium.Presentation.ViewComponents.HomeViewComponents
{
    public class HomeChefsVC : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeChefsVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44308/api/Chefs/Get4Chefs");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultChefDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
