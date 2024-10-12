using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurantium.Business.Concrete;
using Restaurantium.DataAccess.Entities;
using System.Net.Http;

namespace Restaurantium.Presentation.Controllers
{
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            ViewBag.pageName = "Hakkımızda";

            return View();
        }
    }
}
