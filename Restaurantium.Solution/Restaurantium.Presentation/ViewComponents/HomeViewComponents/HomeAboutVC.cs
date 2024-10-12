using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurantium.DataAccess.Entities;
using System.Net.Http.Headers;

namespace Restaurantium.Presentation.ViewComponents.HomeViewComponents
{
   
    public class HomeAboutVC : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public HomeAboutVC(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }
        //[Authorize(Roles ="Admin,Visitor")]
        [AllowAnonymous]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Token'ı alıyoruz
            var token = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;

            // Token null mı kontrol edelim
            //if (token != null)
            //{
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var aboutResponseMessage = await client.GetAsync("https://localhost:44308/api/Abouts");
                var chefsResponseMessage = await client.GetAsync("https://localhost:44308/api/Chefs");
                if (aboutResponseMessage.IsSuccessStatusCode && chefsResponseMessage.IsSuccessStatusCode)
                {
                    var aboutJsonData = await aboutResponseMessage.Content.ReadAsStringAsync();
                    var aboutValues = JsonConvert.DeserializeObject<List<About>>(aboutJsonData);


                    var chefsJsonData = await chefsResponseMessage.Content.ReadAsStringAsync();
                    var chefs = JsonConvert.DeserializeObject<List<Chef>>(chefsJsonData);


                    if (chefs != null)
                        ViewBag.ChefsCount = chefs.Count;

                    return View(aboutValues);
                }
            //}
            





            return View();
        }
    }
}
