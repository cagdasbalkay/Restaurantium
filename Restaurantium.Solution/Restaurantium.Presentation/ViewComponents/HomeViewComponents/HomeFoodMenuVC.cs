using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Restaurantium.Dto.MenuDtos;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class HomeFoodMenuVC : ViewComponent
{ 
    private readonly IHttpClientFactory _httpClientFactory;

    public HomeFoodMenuVC (IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IViewComponentResult> InvokeAsync(int categoryId)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"https://localhost:44308/api/foods/Get8FoodsPerCategory?id={categoryId}");

        if(response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultMenuDto>>(jsonData);
            return View(values);
        }
        return View();

    }
}
