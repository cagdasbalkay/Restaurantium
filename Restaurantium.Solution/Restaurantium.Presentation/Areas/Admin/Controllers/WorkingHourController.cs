using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurantium.Dto.WorkingHourDtos;
using System.Text;

namespace Restaurantium.Presentation.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    [Area("Admin")]
    [Route("Admin/WorkingHour")]
    public class WorkingHourController : Controller
    {

        private IHttpClientFactory _httpClientFactory;

        public WorkingHourController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44308/api/WorkingHours");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultWorkingHourDto>>(jsonData);
                return View(values);
            }


            return View();
        }

        [Route("CreateWorkingHour")]
        [HttpGet]
        public IActionResult CreateWorkingHour()
        {
            return View();

        }


        [Route("CreateWorkingHour")]
        [HttpPost]
        public async Task<IActionResult> CreateWorkingHour(CreateWorkingHourDto createWorkingHourDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createWorkingHourDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44308/api/WorkingHours/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { area = "Admin" });
            }
            return RedirectToAction("Index", new { area = "Admin" });

        }

        [Route("UpdateWorkingHour/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateWorkingHour(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44308/api/WorkingHours/GetWorkingHourById?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<UpdateWorkingHourDto>(jsonData);
                return View(values);
            }

            return View();

        }

        [Route("UpdateWorkingHour/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateWorkingHour(UpdateWorkingHourDto updateWorkingHourDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateWorkingHourDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44308/api/WorkingHours/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { area = "Admin" });
            }
            return RedirectToAction("Index", new { area = "Admin" });

        }

    }
}
