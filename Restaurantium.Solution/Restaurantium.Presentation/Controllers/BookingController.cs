using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurantium.Dto.BookingDtos;
using System.Text;

namespace Restaurantium.Presentation.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.pageName = "Rezervasyon";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingDto createBookingDto)
        {
            ViewBag.pageName = "Rezervasyon";

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:44308/api/Bookings", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Booking");
            }

            // Eğer hata varsa bir mesaj ile geri dönelim
            ModelState.AddModelError(string.Empty, "Rezervasyon sırasında bir hata oluştu.");
            return View(createBookingDto);
        }
    }
}
