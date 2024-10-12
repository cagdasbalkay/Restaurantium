using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurantium.Business.Concrete;
using Restaurantium.DataAccess.Tools;
using Restaurantium.Dto.AppUserDtos;

namespace Restaurantium.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private readonly AppUserManager _appUserManager;

        public SignInController(AppUserManager appUserManager)
        {
            _appUserManager = appUserManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(CheckAppUserDto checkAppUserDto)
        {
            var values = await _appUserManager.ResultCheckAppUserAsync(checkAppUserDto);
            if (values.IsExist)
                return Created("", JwtTokenGenerator.GenerateToken(values));
            else
                return BadRequest("Sorun var");
        }
    }
}
