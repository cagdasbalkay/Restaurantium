using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurantium.Dto.FooterContactDtos;
using System.Text;

namespace Restaurantium.Presentation.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    [Area("Admin")]
    [Route("Admin/FooterContact")]
    public class FooterContactController : Controller
    {

        private IHttpClientFactory _httpClientFactory;

        public FooterContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44308/api/FooterContacts");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultFooterContactDto>>(jsonData);
                return View(values);
            }


            return View();
        }

        [Route("CreateFooterContact")]
        [HttpGet]
        public IActionResult CreateFooterContact()
        {
            return View();

        }

        [Route("CreateFooterContact")]
        [HttpPost]
        public async Task<IActionResult> CreateFooterContact(CreateFooterContactDto createFooterContactDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createFooterContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44308/api/FooterContacts/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { area = "Admin" });
            }
            return RedirectToAction("Index", new { area = "Admin" });

        }

        [Route("UpdateFooterContact/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateFooterContact(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44308/api/FooterContacts/GetFooterContactById?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<UpdateFooterContactDto>(jsonData);
                return View(values);
            }

            return View();

        }

        [Route("UpdateFooterContact/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateFooterContact(UpdateFooterContactDto updateFooterContactDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateFooterContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44308/api/FooterContacts/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { area = "Admin" });
            }
            return RedirectToAction("Index", new { area = "Admin" });

        }


    }
}
