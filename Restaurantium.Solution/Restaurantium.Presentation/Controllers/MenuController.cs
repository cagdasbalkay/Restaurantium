using Microsoft.AspNetCore.Mvc;
using Restaurantium.Dto.MenuDtos;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Restaurantium.Presentation.Controllers
{
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            ViewBag.pageName = "Yemek Menüsü";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> FetchMenuItems(int categoryId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:44308/api/foods/GetFoodsByCategoryId?id={categoryId}");

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest("Öğeleri yükleme işlemi başarısız oldu.");
            }

            var content = await response.Content.ReadAsStringAsync();
            var menuItems = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResultMenuDto>>(content);

            return Json(menuItems);
        }
    }
}
