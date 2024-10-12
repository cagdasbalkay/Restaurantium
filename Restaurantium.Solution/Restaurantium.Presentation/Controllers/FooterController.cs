using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurantium.DataAccess.Entities;
using System.Text;

namespace Restaurantium.Presentation.Controllers
{
    public class FooterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FooterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index([FromBody] Subscribe subscribe)
        {
            if (subscribe == null)
            {
                return BadRequest("Geçersiz veri.");
            }

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(subscribe);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = client.PostAsync("https://localhost:44308/api/Subscribes", content).Result;

            if (response.IsSuccessStatusCode)
            {
                return Ok(); // Başarılıysa 200 OK döndür
            }

            return StatusCode(500, "API'ye veri gönderilirken bir hata oluştu.");
        }

    }
}
