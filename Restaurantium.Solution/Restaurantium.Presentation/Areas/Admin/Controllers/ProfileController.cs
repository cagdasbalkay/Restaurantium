using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurantium.Dto.ProfileDtos;
using System.Net.Http.Headers;

namespace Restaurantium.Presentation.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    [Area("Admin")]
    [Route("Admin/Profile")]
    public class ProfileController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProfileController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("EditProfile")]
        public async Task<IActionResult> EditProfile()
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await client.GetAsync("https://localhost:44308/api/Profile/GetProfile");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();

                    var user = JsonConvert.DeserializeObject<ResultProfileDto>(jsonData);
                   
                    return View(user);


                }
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateProfile")]
        public async Task<IActionResult> UpdateProfile(ResultProfileDto userProfileDto)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try
                {
                    var response = await client.PutAsJsonAsync("https://localhost:44308/api/Profile/UpdateProfile", userProfileDto);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index","About");
                    }
                }
                catch (HttpRequestException ex)
                {
                    // Hata yönetimi: Geliştirici için konsola yazdırma
                    Console.WriteLine($"Request error: {ex.Message}");
                }
            }

            return View("Error");
        }
    }
}
