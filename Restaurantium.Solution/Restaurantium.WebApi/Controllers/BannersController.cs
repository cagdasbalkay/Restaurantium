using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurantium.Business.Concrete;
using Restaurantium.Business.ValidationRules.BannerValidators;
using Restaurantium.DataAccess.Entities;

namespace Restaurantium.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController(BannerManager bannerManager, BannerValidator bannerValidator) : ControllerBase
    {
       private readonly BannerManager _bannerManager = bannerManager;
        private readonly BannerValidator _bannerValidator = bannerValidator;

        [HttpGet]
        public async Task<IActionResult> GetBanners()
        {
            var values = await _bannerManager.GetAll();
            return Ok(values);
        }
        [HttpGet("GetBannerById")]
        public async Task<IActionResult> GetBannerById(int id)
        {
            var values = await _bannerManager.GetById(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBanner(Banner banner)
        {
            var validationResult = await _bannerValidator.ValidateAsync(banner);
            if(validationResult.IsValid)
            {
                await _bannerManager.Create(banner);
                return Ok("Başarıyla oluşturuldu");
            }
            return BadRequest(validationResult.Errors);
            
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBanner(Banner banner)
        {
            var validationResult = await _bannerValidator.ValidateAsync(banner);
            if(validationResult.IsValid)
            {
                await _bannerManager.Update(banner);
                return Ok("Başarıyla güncellendi");
            }
            return BadRequest(validationResult.Errors);
            
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            var value = await _bannerManager.GetById(id);
            await _bannerManager.Delete(value);
            return Ok("Başarıyla silindi");
        }
    }
}
