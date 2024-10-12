using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurantium.Dto.ContactDtos;

namespace Restaurantium.Presentation.Areas.Admin.ViewComponents.DashboardViewComponents
{
    public class DashboardContactMessagesVC : ViewComponent
    {
        private IHttpClientFactory _httpClientFactory;

        public DashboardContactMessagesVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44308/api/Contacts/GetLast5ContactMessages");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                return View(values);
            }


            return View();
        }
    }
}
