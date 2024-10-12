using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurantium.DataAccess.ViewModels;

namespace Restaurantium.Presentation.ViewComponents.LayoutViewComponents
{
    public class FooterVC : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FooterVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44308/api/Footers");

            var response2 = await client.GetAsync("https://localhost:44308/api/CompanySocialMedias");

            if (response.IsSuccessStatusCode && response2.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var viewModel = JsonConvert.DeserializeObject<FooterViewModel>(jsonData);

                var jsonData2 = await response2.Content.ReadAsStringAsync();
                var socialMedias = JsonConvert.DeserializeObject<List<ResultCompanySocialMediaViewModel>>(jsonData2);

                ViewBag.CompanySocialMediaList = socialMedias;
                return View(viewModel);
            }

            return View(new FooterViewModel());

        }
    }
}
