using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurantium.DataAccess.Abstract;
using Restaurantium.DataAccess.Concrete.Repositories.FooterRepositories;

namespace Restaurantium.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootersController : ControllerBase
    {
        private readonly IFooterDal _footerDal;

        public FootersController(IFooterDal footerRepository)
        {
            _footerDal = footerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetFooterData()
        {
            var footerData = await _footerDal.GetFooterDataAsync();
            return Ok(footerData);
        }
    }
}
