using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurantium.Dto.BookingDtos;
using System.Net.Http.Headers;
using System.Text;

namespace Restaurantium.Presentation.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    [Area("Admin")]
    [Route("Admin/Booking")]
    public class BookingController : Controller
    {

        private IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var responseMessage = await client.GetAsync("https://localhost:44308/api/Bookings");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();

                    var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                    return View(values);
                }
            }

            return View();
        }

        [Route("UpdateBooking/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var responseMessage = await client.GetAsync($"https://localhost:44308/api/Bookings/GetBookingById?id={id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();

                    var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
                    return View(values);
                }
            }
            return View();

        }

        [Route("UpdateBooking/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var jsonData = JsonConvert.SerializeObject(updateBookingDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("https://localhost:44308/api/Bookings/", stringContent);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", new { area = "Admin" });
                }
            }
            return RedirectToAction("Index", new { area = "Admin" });

        }

        [Route("RemoveBooking/{id}")]
        public async Task<IActionResult> RemoveBooking(int id)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var responseMessage = await client.DeleteAsync($"https://localhost:44308/api/Bookings?id={id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", new { area = "Admin" });
                }
            }
            return RedirectToAction("Index", new { area = "Admin" });

        }

    }
}
