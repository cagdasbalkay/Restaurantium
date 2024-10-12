using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurantium.Dto.BannerDtos;

namespace Restaurantium.Presentation.ViewComponents.HomeViewComponents
{
    public class HomeBannerVC : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeBannerVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44308/api/Banners");
            if(responseMessage.IsSuccessStatusCode)
            {
              var jsonData =  await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
