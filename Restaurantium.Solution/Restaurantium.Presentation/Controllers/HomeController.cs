using Microsoft.AspNetCore.Mvc;
using Restaurantium.Presentation.Models;
using Restaurantium.Dto.MenuDtos;
using System.Diagnostics;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;

namespace Restaurantium.Presentation.Controllers
{
    //[Authorize(Roles = "Visitor")]
    public class HomeController : Controller
    {
        private readonly IViewComponentHelper _viewComponentHelper;

        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory, IViewComponentHelper viewComponentHelper)
        {
            _httpClientFactory = httpClientFactory;
            _viewComponentHelper = viewComponentHelper;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> FetchMenuItems(int categoryId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:44308/api/Foods/Get8FoodsPerCategory?id={categoryId}");

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest("Öðeleri yükleme iþlemi baþarýsýz oldu.");
            }

            var content = await response.Content.ReadAsStringAsync();
            var menuItems = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResultMenuDto>>(content);

            return Json(menuItems);
        }

    }
}
