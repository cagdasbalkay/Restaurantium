using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurantium.Dto.CompanySocialMediaDtos;
using System.Text;

namespace Restaurantium.Presentation.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    [Area("Admin")]
    [Route("Admin/CompanySocialMedia")]
    public class CompanySocialMediaController : Controller
    {

        private IHttpClientFactory _httpClientFactory;

        public CompanySocialMediaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44308/api/CompanySocialMedias");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultCompanySocialMediaDto>>(jsonData);
                return View(values);
            }


            return View();
        }

        [Route("CreateCompanySocialMedia")]
        [HttpGet]
        public IActionResult CreateCompanySocialMedia()
        {
            return View();

        }


        [Route("CreateCompanySocialMedia")]
        [HttpPost]
        public async Task<IActionResult> CreateCompanySocialMedia(CreateCompanySocialMediaDto createCompanySocialMediaDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCompanySocialMediaDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44308/api/CompanySocialMedias/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { area = "Admin" });
            }
            return RedirectToAction("Index", new { area = "Admin" });

        }

        [Route("UpdateCompanySocialMedia/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateCompanySocialMedia(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44308/api/CompanySocialMedias/GetCompanySocialMediaById?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<UpdateCompanySocialMediaDto>(jsonData);
                return View(values);
            }

            return View();

        }

        [Route("UpdateCompanySocialMedia/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateCompanySocialMedia(UpdateCompanySocialMediaDto updateCompanySocialMediaDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCompanySocialMediaDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44308/api/CompanySocialMedias/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { area = "Admin" });
            }
            return RedirectToAction("Index", new { area = "Admin" });

        }

        [Route("RemoveCompanySocialMedia/{id}")]
        public async Task<IActionResult> RemoveCompanySocialMedia(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44308/api/CompanySocialMedias?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { area = "Admin" });
            }
            return RedirectToAction("Index", new { area = "Admin" });

        }

    }
}
